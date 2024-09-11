using RobotApp.Logic.RobotLogic;
using RobotApp.Models.Enums;

namespace RobotApp.Tests
{
    [TestClass]
    public class DirectionalLogicUnitTests : GlobalTestSetup
    {
        public new void Initalise()
        {
            base.Initalise();
        }

        [TestMethod]
        public void GetValidDirectionFromString_ValidInput_ReturnsCorrectDirection()
        {
            // Arrange
            string directionString = "NE";

            // Act
            Direction direction = DirectionLogic.GetValidDirectionFromString(directionString);

            // Assert
            Assert.AreEqual(Direction.NorthEast, direction);
        }

        [TestMethod]
        public void GetValidDirectionFromString_OneCharInput_ReturnsCorrectDirection()
        {
            // Arrange
            string directionString = "N";

            // Act
            Direction direction = DirectionLogic.GetValidDirectionFromString(directionString);

            // Assert
            Assert.AreEqual(Direction.North, direction);
        }


        [TestMethod]
        public void GetValidDirectionFromString_InvalidInput_ReturnsErrorDirection()
        {
            // Arrange
            string directionString = "ZK";

            // Act
            Direction direction = DirectionLogic.GetValidDirectionFromString(directionString);

            // Assert
            Assert.AreEqual(Direction.Error, direction);
        }

        [TestMethod]
        public void GetValidDirectionFromString_ShortInput_ReturnsErrorDirection()
        {
            // Arrange
            string directionString = "";

            // Act
            Direction direction = DirectionLogic.GetValidDirectionFromString(directionString);

            // Assert
            Assert.AreEqual(Direction.Error, direction);
        }
    }
}
