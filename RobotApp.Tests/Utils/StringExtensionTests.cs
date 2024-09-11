using RobotApp.Utils;

namespace RobotApp.Tests.Utils
{

    [TestClass]
    public class StringExtensionTests
    {
        [TestMethod]
        public void GetValidTuple_ValidInput_ReturnsTuple()
        {
            // Arrange 
            string validInput = "OBSTACLE 1 2";

            // Act
            var potentialTuple = validInput.GetValidTuple();

            // Assert
            Assert.IsNotNull(potentialTuple);
        }

        [TestMethod]
        public void GetValidTuple_InalidInput_ReturnsNull()
        {
            // Arrange 
            string validInput = "OBSTACLE 1";

            // Act
            var potentialTuple = validInput.GetValidTuple();

            // Assert
            Assert.IsNull(potentialTuple);
        }
    }
}
