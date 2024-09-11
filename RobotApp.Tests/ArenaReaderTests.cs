using Moq;
using RobotApp.Models;
using RobotApp.Utils.Interfaces;

namespace RobotApp.Tests
{
    [TestClass]
    public class ArenaReaderTests
    {
        Grid ValidGrid = Grid.Instance(10, 10);
        Mock<IRobotFactory<string[]>> mockRobotFactory = new Mock<IRobotFactory<string[]>>();
        Mock<IArenaReader<string[]>> mockArenaRead = new Mock<IArenaReader<string[]>>();


        [TestInitialize]
        public void Setup()
        {
            mockRobotFactory.Setup(mrf => mrf.ConstructRobot(ValidGrid));
            mockArenaRead.Setup(mar => mar.ConstructArena()).Returns(ValidGrid);
            mockArenaRead.Setup(mar => mar.PlaceObstacles(It.IsAny<Grid>(), It.IsAny<string>())).Returns(ValidGrid);
        }


        [DataTestMethod]
        [DataRow("OBSTACLE 1 2")]
        public void ObstacleConstructionTests(string obstacleString)
        {
            // Organise
            var mockObstacle = obstacleString;
            mockArenaRead.Setup(mar => mar.ConstructArena()).Returns(Grid.Instance(10, 10));

            mockArenaRead.Setup(mol => mol.PlaceObstacles(It.IsAny<Grid>(), It.IsAny<string>())).Returns(Grid.Instance(10, 10));

            Grid.Instance(10, 10).obstacles.Add(new Obstacle(1, 2));

            // Test

            // Validate
            if (obstacleString != null)
            {
                mockArenaRead.Object.PlaceObstacles(ValidGrid, obstacleString);
                Assert.IsTrue(ValidGrid.obstacles.Count != 0);
            }

        }
    }
}
