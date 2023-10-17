using KorliakovBackendTestTask;
using KorliakovBackendTestTask.Models;
using KorliakovBackendTestTask.Repository;
using KorliakovBackendTestTask.Utils;
using Microsoft.Extensions.Logging;
using Moq;

namespace MsTest;

[TestClass]
public class ExperimentHelperTests {
    private static readonly PriceProbability[] PriceProbabilities = {
        new() {
            Value = 10,
            Probability = 75
        },
        new() {
            Value = 20,
            Probability = 10
        },
        new() {
            Value = 50,
            Probability = 5
        },
        new() {
            Value = 5,
            Probability = 10
        }
    };

    private static readonly string[] Colors = {
        "#FF0000",
        "#00FF00",
        "#0000FF"
    };

    [TestMethod]
    public void TestGetButtonColor() {
        // Arrange
        var mockLogger = new Mock<ILogger<ExperimentHelper>>();
        var mockRepository = new Mock<IRepository<Client>>();

        var helper = new ExperimentHelper(mockLogger.Object, mockRepository.Object, Colors, PriceProbabilities);

        const string deviceToken = "someDeviceToken";

        // Act
        var color = helper.GetButtonColor(deviceToken);

        // Assert
        CollectionAssert.Contains(Colors, color);
    }

    [TestMethod]
    public void TestGetPrice() {
        // Arrange
        var mockLogger = new Mock<ILogger<ExperimentHelper>>();
        var mockRepository = new Mock<IRepository<Client>>();

        var helper = new ExperimentHelper(mockLogger.Object, mockRepository.Object, Colors, PriceProbabilities);

        const string deviceToken = "someDeviceToken";

        // Act
        var price = helper.GetPrice(deviceToken);

        // Assert
        Assert.IsTrue(price is >= 5 and <= 50);
    }
}