using Newtonsoft.Json;

namespace KorliakovBackendTestTask.Schema;

public struct ExperimentResponse {
    [JsonProperty("key")]
    public required string Key { get; set; }

    [JsonProperty("value")]
    public required dynamic Value { get; set; }
}