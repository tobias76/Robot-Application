using RobotApp.Models.Enums;

namespace RobotApp.Models
{
    public class RobotMission
    {

        public Cell? StartPoint;
        public Cell? EndPoint;
        public Direction StartingDirection = Direction.Error;
        public string? Moves;

        public RobotMission(Cell startPoint, Cell endPoint, string moves, Direction direction)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Moves = moves;
            StartingDirection = direction;
        }

        public RobotMission()
        {

        }
    }
}
