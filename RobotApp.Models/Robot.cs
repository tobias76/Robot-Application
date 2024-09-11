using RobotApp.Models.Enums;

namespace RobotApp.Models
{
    public class Robot
    {
        private static Robot? _instance = null;
        private static readonly object maximumSecurityGuard = new object();

        private Direction currentDirection;
        private Cell currentLocation;
        private RobotState robotState;

        public static Robot Instance(Direction facing = Direction.Error, Cell cell = null, RobotState state = RobotState.Error)
        {
            lock (maximumSecurityGuard)
            {
                if (_instance == null)
                {
                    return _instance = new Robot(facing, cell, state);
                }
                else
                {
                    return _instance;
                }
            }
        }

        private Robot(Direction facing, Cell cell, RobotState state)
        {
            currentDirection = facing;
            currentLocation = cell;
            robotState = state;
        }

        public static Direction GetDirection()
        {
            return _instance.currentDirection;
        }

        public static void SetDirection(Direction direction)
        {
            _instance.currentDirection = direction;

        }

        public static Cell GetCurrentCell()
        {
            return _instance.currentLocation;
        }

        public static Robot SetCurrentCell(int xLocation, int yLocation)
        {
            _instance.currentLocation = new Cell(xLocation, yLocation);
            return _instance;
        }

        public static Robot SetCurrentState(RobotState state)
        {
            _instance.robotState = state;
            return _instance;
        }

        public static RobotState GetRobotState()
        {
            return _instance.robotState;
        }
    }
}
