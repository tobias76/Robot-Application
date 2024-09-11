using Moq;
using RobotApp.Models;
using RobotApp.Utils.Interfaces;

namespace RobotApp.Tests
{
    [TestClass]
    public class RobotUnitTests : GlobalTestSetup
    {
        private Mock<IRobotFactory<string[]>> _mockRobotFactory;

        [TestInitialize]
        public new void Initalise()
        {
            base.Initalise();
            _mockRobotFactory = new Mock<IRobotFactory<string[]>>();
        }

        [TestMethod]
        public void SetCurrentCell_ValidInput_UpdatesRobotLocation()
        {
            // Arrange
            int x = 1;
            int y = 1;

            // Act
            Robot.SetCurrentCell(x, y);

            // Assert
            Assert.AreEqual(x, Robot.GetCurrentCell().GetX());
            Assert.AreEqual(y, Robot.GetCurrentCell().GetY());
        }
    }
}
