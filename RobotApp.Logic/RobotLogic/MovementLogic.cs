using RobotApp.Models;
using RobotApp.Models.Enums;

namespace RobotApp.Logic.RobotLogic
{
    /// <summary>
    /// A static class to contain all logic related to the moving of the robot.
    /// </summary>
    public static class MovementLogic
    {
        /// <summary>
        /// A method to take a degree value, alter the current direction by it and get it's directional value.
        /// </summary>
        /// <param name="newDirection">A value to alter the direction by.</param>
        /// <returns> A new Directional value for the robot to face.</returns>
        public static Direction GetDirectionByInt(int newDirection)
        {
            Direction currentDirection = Robot.GetDirection();
            Direction dirByInt;

            if ((int)currentDirection + newDirection >= 360)
            {
                dirByInt = (Direction)(((int)currentDirection + newDirection) % 360);

            }
            else if ((int)currentDirection + newDirection < 0)
            {
                dirByInt = (Direction)(Math.Abs(((int)currentDirection + newDirection) % 360));

            }
            else
            {

                dirByInt = currentDirection += newDirection;
            }
            return dirByInt;
        }

        /// <summary>
        /// A method to translate a potential Movement character and translate it into a direction for the robot if the movement is valid.
        /// </summary>
        /// <param name="Movement">Character to translate.</param>
        public static void InputToInstruction(char Movement)
        {
            Direction direction = Robot.GetDirection();

            if (Robot.GetRobotState() == RobotState.Alive)
            {
                switch (Movement)
                {
                    case 'R':
                        Robot.SetDirection(GetDirectionByInt(90));
                        break;
                    case 'L':
                        Robot.SetDirection(GetDirectionByInt(-90));
                        break;
                    case 'F':
                        int newX;
                        int newY;
                        Cell currentCell = Robot.GetCurrentCell();

                        if (direction == Direction.North)
                        {
                            newY = currentCell.GetY() + 1;

                            if (ValidMovement(currentCell.GetX(), newY: newY))
                            {
                                Robot.SetCurrentCell(currentCell.GetX(), newY);
                            }
                            break;

                        }
                        else if (direction == Direction.South)
                        {
                            newY = currentCell.GetY() - 1;

                            if (ValidMovement(currentCell.GetX(), newY: newY))
                            {
                                Robot.SetCurrentCell(currentCell.GetX(), newY);
                            }

                            break;

                        }
                        else if (direction == Direction.East)
                        {
                            newX = currentCell.GetX() + 1;

                            if (ValidMovement(newX: newX, currentCell.GetY()))
                            {
                                Robot.SetCurrentCell(newX, currentCell.GetY());
                            }

                            break;
                        }
                        else if (direction == Direction.West)
                        {
                            newX = currentCell.GetX() - 1;

                            if (ValidMovement(newX: newX, currentCell.GetY()))
                            {
                                Robot.SetCurrentCell(newX, currentCell.GetY());
                            }
                            break;

                        }
                        break;
                }
            }
            else
            {
                return;
            }

        }

        /// <summary>
        /// This method checks if the new location for a robot is not out of bounds and doesn't include an obstacle. If it does it sets the robots state.
        /// </summary>
        /// <param name="newX">New X Location to check.</param>
        /// <param name="newY">New Y Location to check.</param>
        /// <returns>True if the robot can move, false if it can not.</returns>
        public static bool ValidMovement(int newX = 0, int newY = 0)
        {
            if (Grid.Instance(0, 0).obstacles.Any(x => x.position.GetX() == newX && x.position.GetY() == newY))
            {
                Robot.SetCurrentState(RobotState.Crashed);
                return false;
            }
            else if (newX < 0 || newY < 0 || newX > Grid.GetWidth() || newY > Grid.GetHeight())
            {
                Robot.SetCurrentState(RobotState.OutOfBounds);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
