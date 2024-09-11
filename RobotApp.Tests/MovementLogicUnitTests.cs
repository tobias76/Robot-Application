using RobotApp.Logic.RobotLogic;
using RobotApp.Models;
using RobotApp.Models.Enums;

namespace RobotApp.Tests
{
    [TestClass]
    public class MovementLogicUnitTests : GlobalTestSetup
    {

        [TestInitialize]
        public void Initalise()
        {
            base.Initalise();

            Robot.SetCurrentCell(1, 1);
            Robot.SetCurrentState(RobotState.Alive);
        }

        [TestMethod]
        public void GetDirectionByInt_ValidPositiveInput_ReturnsCorrectDirection()
        {
            // Arrange
            Robot.SetDirection(Direction.North);

            // Act
            Direction result = MovementLogic.GetDirectionByInt(90);

            // Assert
            Assert.AreEqual(Direction.East, result);
        }

        [TestMethod]
        public void GetDirectionByInt_ValidNegativeInput_ReturnsCorrectDirection()
        {
            // Arrange
            Robot.SetDirection(Direction.North);

            // Act
            Direction result = MovementLogic.GetDirectionByInt(-180);

            // Assert
            Assert.AreEqual(Direction.South, result);
        }

        [TestMethod]
        public void GetDirectionByInt_LoopPastLimit_ReturnsCorrectDirection()
        {
            // Arrange
            Robot.SetDirection(Direction.North);

            // Act
            Direction result = MovementLogic.GetDirectionByInt(450);

            // Assert
            Assert.AreEqual(Direction.East, result);
        }

        [TestMethod]
        public void GetDirectionByInt_NegativeLoopPastLimit_ReturnsCorrectDirection()
        {
            // Arrange
            Robot.SetDirection(Direction.North);

            // Act
            Direction result = MovementLogic.GetDirectionByInt(-450);

            // Assert
            Assert.AreEqual(Direction.East, result);
        }

        [TestMethod]
        public void GetDirectionByInt_ZeroInput_ReturnsCurrentDirection()
        {
            // Arrange
            Robot.SetDirection(Direction.NorthEast);

            // Act
            Direction result = MovementLogic.GetDirectionByInt(0);

            // Assert
            Assert.AreEqual(Direction.NorthEast, result);
        }

        [TestMethod]
        public void ValidMovement_ZeroObstaclesValidMovement_ReturnsAlive()
        {
            // Arrange
            Grid.Instance(0, 0).obstacles.Clear();

            // Act
            bool result = MovementLogic.ValidMovement(1, 2);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(RobotState.Alive, Robot.GetRobotState());
        }

        [TestMethod]
        public void ValidMovement_OneObstaclesValidMovement_ReturnsAlive()
        {
            // Arrange
            Grid.Instance(0, 0).obstacles.Add(new Obstacle(1, 2));

            // Act
            bool result = MovementLogic.ValidMovement(1, 2);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(RobotState.Crashed, Robot.GetRobotState());
        }

        [TestMethod]
        public void ValidMovement_OutOfBoundsValidMovement_ReturnsOutOfBounds()
        {
            // Arrange 
            Robot.SetCurrentCell(10, 10);

            // Act
            bool result = MovementLogic.ValidMovement(11, 11);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(RobotState.OutOfBounds, Robot.GetRobotState());
        }


        [DataTestMethod]
        [DataRow(Direction.North, 1, 2)]
        [DataRow(Direction.West, 0, 1)]
        [DataRow(Direction.South, 1, 0)]
        [DataRow(Direction.East, 2, 1)]
        public void InputToInstruction_Forward_ReturnsCorrectCell(Direction directionOfTravel, int expectedX, int expectedY)
        {
            // Arrange
            Robot.SetDirection(directionOfTravel);

            // Act
            MovementLogic.InputToInstruction('F');

            // Assert
            Assert.AreEqual(expectedY, Robot.GetCurrentCell().GetY());
            Assert.AreEqual(expectedX, Robot.GetCurrentCell().GetX());
        }
    }
}
