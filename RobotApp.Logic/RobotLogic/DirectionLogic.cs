using RobotApp.Models.Enums;
using System.Text.RegularExpressions;

namespace RobotApp.Logic.RobotLogic
{
    public static class DirectionLogic
    {

        public static Direction GetDirectionByString(string substring)
        {
            if (substring.Length != 0)
            {
                if (substring.Length > 1)
                {
                    switch (substring)
                    {
                        case "NE":
                            return Direction.NorthEast;
                        case "NW":
                            return Direction.NorthWest;
                        case "SE":
                            return Direction.SouthEast;
                        case "SW":
                            return Direction.SouthWest;
                    }
                }
                else
                {
                    switch (substring)
                    {
                        case "N":
                            return Direction.North;
                        case "W":
                            return Direction.West;
                        case "E":
                            return Direction.East;
                        case "S":
                            return Direction.South;
                    }
                }
            }
            return Direction.Error;
        }

        public static Direction GetValidDirectionFromString(string direction)
        {
            Match Match = Regex.Match(direction, @"[A-Za-z]+");

            if (Match.Success)
            {
                return GetDirectionByString(Match.Value);
            }
            else
            {
                return Direction.Error;
            }

        }
    }
}
