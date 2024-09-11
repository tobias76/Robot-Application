using RobotApp.Logic.RobotLogic;
using RobotApp.Models;
using RobotApp.Models.Enums;

namespace RobotApp.Utils
{
    public static class FileLogic
    {
        /// <summary>
        /// This goes through all contents provided and creates missions for our robot to undertake, 
        /// to gracefully handle issues it doesn't throw exceptions. It breaks out and ignores the mission.
        /// </summary>
        /// <param name="fileContents"> Data to *hopefully* create missions out of.</param>
        /// <returns></returns>
        public static List<RobotMission> ReadIntoRobotMissionLog(IEnumerable<string> fileContents)
        {
            var missions = new List<RobotMission>();
            RobotMission? currentMission = null;

            foreach (var item in fileContents)
            {
                if (!item.Contains("GRID") && item != "" && !item.Contains("OBSTACLE"))
                {
                    var validTuple = item.GetValidTuple();

                    if (validTuple != null)
                    {
                        if (currentMission == null)
                        {
                            currentMission = new RobotMission();

                            if (currentMission.StartingDirection == Direction.Error)
                            {
                                currentMission.StartingDirection = DirectionLogic.GetValidDirectionFromString(item);
                            }

                            currentMission.StartPoint = new Cell(validTuple.Item1, validTuple.Item2);
                        }
                        else if (currentMission.EndPoint == null)
                        {
                            currentMission.EndPoint = new Cell(validTuple.Item1, validTuple.Item2);
                        }
                        else
                        {
                            Console.WriteLine("Too many starting/ending points provided, breaking into next mission");
                            break;
                        }
                    }
                    else
                    {
                        if (currentMission != null && currentMission.Moves == null)
                        {
                            currentMission.Moves = item;
                        }
                        else
                        {
                            Console.WriteLine("Issue with moves provided, breaking into next mission");
                            break;

                        }
                    }
                }

                if (currentMission != null && currentMission.EndPoint != null && currentMission.StartPoint != null && currentMission.Moves != null && currentMission.StartingDirection != Direction.Error)
                {
                    missions.Add(currentMission);
                    currentMission = null;
                }
            }

            return missions;
        }
    }
}
