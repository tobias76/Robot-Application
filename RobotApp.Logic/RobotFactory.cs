using RobotApp.Logic.RobotLogic;
using RobotApp.Models;
using RobotApp.Models.Enums;
using RobotApp.Utils.Interfaces;

namespace RobotApp.Utils
{
    public sealed class RobotFactory<T> : FileReader<T>, IRobotFactory<T> where T : class
    {
        public RobotFactory(string[] filePath) : base(filePath)
        {

        }

        public void ConstructRobot(Grid grid)
        {
            Console.WriteLine("Constructing Robot.");

            foreach (var line in fileContents)
            {
                if (!line.Contains("OBSTACLE") && !line.Contains("GRID") && line.Length > 1)
                {
                    if (Robot.Instance != null)
                    {
                        var robotStartingLocation = line.Split(' ');

                        var robotDirection = DirectionLogic.GetDirectionByString(robotStartingLocation[2]);

                        Robot.Instance(robotDirection, new Cell(Convert.ToInt32(robotStartingLocation[0]), Convert.ToInt32(robotStartingLocation[1])), RobotState.Alive);
                        Console.WriteLine("Robot constructed.");

                        return;
                    }
                }
            }
        }
    }
}
