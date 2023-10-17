using Dapper.Contrib.Extensions;

namespace KorliakovBackendTestTask.Models;

[System.ComponentModel.DataAnnotations.Schema.Table("Client")]
public class Client {
    [ExplicitKey]
    public required string DeviceToken { get; set; }

    public required string Color { get; set; }

    public required int Price { get; set; }
}