using KorliakovBackendTestTask.Schema;
using KorliakovBackendTestTask.Utils;
using Microsoft.AspNetCore.Mvc;

namespace KorliakovBackendTestTask.Controllers;

[ApiController]
[Route("[controller]")]
public class ExperimentController : ControllerBase {
    private const string ButtonColor = "button_color";
    private const string Price = "price";
    private const string DeviceToken = "device-token";

    private readonly IExperimentHelper _experimentHelper;

    public ExperimentController(
        IExperimentHelper experimentHelper) {
        _experimentHelper = experimentHelper;
    }
    
    [HttpGet(ButtonColor)]
    public ExperimentResponse GetButtonColor([FromQuery(Name = DeviceToken)] string deviceToken) {
        return new ExperimentResponse {
            Key = ButtonColor,
            Value = _experimentHelper.GetButtonColor(deviceToken)
        };
    }

    [HttpGet(Price)]
    public ExperimentResponse GetPrice([FromQuery(Name = DeviceToken)] string deviceToken) {
        return new ExperimentResponse {
            Key = Price,
            Value = _experimentHelper.GetPrice(deviceToken)
        };
    }
}