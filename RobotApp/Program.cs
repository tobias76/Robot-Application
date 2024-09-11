using RobotApp.Logic.ArenaLogic;
using RobotApp.Logic.RobotLogic;
using RobotApp.Models;
using RobotApp.Models.Enums;
using RobotApp.Utils;
using System;

namespace RobotApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ArenaReader<string[]> reader = new ArenaReader<string[]>(args);

            Grid arena = reader.ConstructArena();

            Console.WriteLine("Grid created successfully with the following parameters, X Size: {0}, Y Size: {1}, Obstacles: {2}", Grid.GetWidth(), Grid.GetHeight(), arena.obstacles.Count);
            Console.WriteLine("Your robot has been constructed and placed in the following direction: {0} on the cell in space X: {1} Y: {2}", Robot.GetDirection(), Robot.GetCurrentCell().GetX(), Robot.GetCurrentCell().GetY());

            FileObject.Instance().robotMissions = FileLogic.ReadIntoRobotMissionLog(reader.fileContents);

            foreach (var mission in FileObject.Instance().robotMissions)
            {
                Robot.SetCurrentCell(mission.StartPoint.GetX(), mission.StartPoint.GetY());
                Robot.SetDirection(mission.StartingDirection);

                foreach (var move in mission.Moves)
                {
                    MovementLogic.InputToInstruction(move);

                    if (Robot.GetRobotState() == RobotState.Crashed)
                    {
                        Console.WriteLine("FAILURE: {0} {1} {2}", Robot.GetCurrentCell().GetX(), Robot.GetCurrentCell().GetY(), Robot.GetDirection());
                        break;
                    }
                    else if (Robot.GetRobotState() == RobotState.OutOfBounds)
                    {
                        Console.WriteLine("OUT OF BOUNDS");
                        break;
                    }
                }

                if (Robot.GetRobotState() != RobotState.Crashed && Robot.GetRobotState() != RobotState.OutOfBounds)
                {
                    if (mission.EndPoint.GetY() == Robot.GetCurrentCell().GetY() && mission.EndPoint.GetX() == Robot.GetCurrentCell().GetX())
                    {
                        Console.WriteLine("SUCCESS: {0} {1} {2}", Robot.GetCurrentCell().GetX(), Robot.GetCurrentCell().GetY(), Robot.GetDirection());
                    }
                    else
                    {
                        Console.WriteLine("MISSION FAILED: Robot ended up at {0} {1} {2} ", Robot.GetCurrentCell().GetX(), Robot.GetCurrentCell().GetY(), Robot.GetDirection());
                    }
                }
            }
        }
    }
}
