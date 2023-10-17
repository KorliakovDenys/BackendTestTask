using KorliakovBackendTestTask.Controllers;
using KorliakovBackendTestTask.Utils;
using Moq;

namespace MsTest; 

[TestClass]
public class ExperimentControllerTests {
    [TestMethod]
    public void TestGetButtonColor() {
        // Arrange
        const string expected = "someColor";
        var mockExperimentHelper = new Mock<IExperimentHelper>();
        mockExperimentHelper.Setup(helper => helper.GetButtonColor(It.IsAny<string>()))
            .Returns(expected);

        var controller = new ExperimentController(mockExperimentHelper.Object);

        // Act
        var result = controller.GetButtonColor("someDeviceToken");

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("button_color", result.Key);
        Assert.AreEqual(expected, result.Value);
    }

    [TestMethod]
    public void TestGetPrice() {
        // Arrange
        const int expected = 10;
        var mockExperimentHelper = new Mock<IExperimentHelper>();
        mockExperimentHelper.Setup(helper => helper.GetPrice(It.IsAny<string>()))
            .Returns(expected);

        var controller = new ExperimentController(mockExperimentHelper.Object);

        // Act
        var result = controller.GetPrice("someDeviceToken");

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("price", result.Key);
        Assert.AreEqual(expected, result.Value);
    }
}