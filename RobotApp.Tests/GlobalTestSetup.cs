using RobotApp.Models;

namespace RobotApp.Tests
{
    [TestClass]
    public class GlobalTestSetup
    {
        private Robot robot;

        [TestMethod]
        public void Initalise()
        {
            robot = Robot.Instance();
            Grid.Instance(10, 10);

        }
    }
}
