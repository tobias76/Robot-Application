using RobotApp.Logic.ArenaLogic;
using RobotApp.Models;

namespace RobotApp.Tests
{
    /// <summary>
    /// Simple unit tests to test that both valid and invalid inputs are handled gracefully.
    /// </summary>
    [TestClass]
    public class ObstacleLogicTests : GlobalTestSetup
    {
        [TestInitialize]
        public new void Initialise()
        {
            base.Initalise();
        }

        [TestMethod]
        public void ValidObstacle_ValidInput_GeneratesObstacle()
        {
            // Arrange
            string validObstacle = "OBSTACLE 1 2";

            // Act
            Obstacle result = ObstacleLogic.ValidObstacle(validObstacle);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ValidObstacle_InvalidInput_DoesNotGenerateObstacle()
        {
            // Arrange
            string validObstacle = "OBSTACLE 1";

            // Act
            Obstacle result = ObstacleLogic.ValidObstacle(validObstacle);

            // Assert
            Assert.IsNull(result);
        }
    }
}
