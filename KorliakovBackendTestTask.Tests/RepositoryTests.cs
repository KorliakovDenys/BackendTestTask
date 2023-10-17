using System.Data;
using Dapper.Contrib.Extensions;
using KorliakovBackendTestTask.Models;
using KorliakovBackendTestTask.Repository;
using Microsoft.Data.SqlClient;

namespace MsTest;

[TestClass]
public class RepositoryTests {
    private IDbConnection _dbConnection;
    private Repository<Client> _repository;
    private Client _client;

    [TestInitialize]
    public void Initialize() {
        const string connectionString =
            "***";
        _dbConnection = new SqlConnection(connectionString);
        _repository = new Repository<Client>(_dbConnection);
        const string deviceToken = "someDeviceToken"; 
        _client = new Client {
            DeviceToken = deviceToken,
            Color = "#FF0000",
            Price = 10
        };
    }

    [TestMethod]
    public void TestCreate() {
        // Act
        var result = _repository.Create(_client);

        // Assert
        Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void TestRead() {
        // Act
        var result = _repository.Read(_client.DeviceToken);

        //Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(_client.DeviceToken, result.DeviceToken);
        Assert.AreEqual(_client.Color, result.Color);
        Assert.AreEqual(_client.Price, result.Price);
    }

    [TestMethod]
    public void TestUpdate() {
        // Act
        _repository.Update(_client);
        var result = _dbConnection.Get<Client>(_client.DeviceToken);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(_client.DeviceToken, result.DeviceToken);
        Assert.AreEqual(_client.Color, result.Color);
        Assert.AreEqual(_client.Price, result.Price);
    }

    [TestMethod]
    public void TestDelete() {
        // Act
        _repository.Delete(_client);

        // Assert
        var result = _dbConnection.Get<Client>(_client.DeviceToken);

        // Assert
        Assert.IsNull(result);
    }
}
