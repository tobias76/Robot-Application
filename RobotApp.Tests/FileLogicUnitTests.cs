using RobotApp.Utils;

namespace RobotApp.Tests
{
    [TestClass]
    public class FileLogicUnitTests
    {

        [TestMethod]
        public void ReadIntoMissionLogic_ValidInput_CreatesMission()
        {
            // Arrange
            IEnumerable<string> strippedValidMissionContent = new List<string> { "1 1 E",
                " RFR ",
                " 1 0 W " };

            // Act
            var missionLog = FileLogic.ReadIntoRobotMissionLog(strippedValidMissionContent);

            // Assert
            Assert.AreEqual(1, missionLog.Count);
        }


        [TestMethod]
        public void ReadIntoMissionLogic_InvalidInput_GracefullySkipsMission()
        {
            // Arrange
            IEnumerable<string> strippedValidMissionContent = new List<string> { "1 1 E" +
                " RFR " +
                " 1 0 W " };

            // Act
            var missionLog = FileLogic.ReadIntoRobotMissionLog(strippedValidMissionContent);

            // Assert
            Assert.AreEqual(0, missionLog.Count);
        }

        [TestMethod]
        public void ReadIntoMissionLogic_SemiCompleteInput_GracefullySkipsMission()
        {
            // Arrange
            IEnumerable<string> strippedValidMissionContent = new List<string> { "1 1 E" ,
                " RFR " };

            // Act
            var missionLog = FileLogic.ReadIntoRobotMissionLog(strippedValidMissionContent);

            // Assert
            Assert.AreEqual(0, missionLog.Count);
        }
    }
}
