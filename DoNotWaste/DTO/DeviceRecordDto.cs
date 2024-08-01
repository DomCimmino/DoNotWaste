using Newtonsoft.Json;

namespace DoNotWaste.DTO;

public class DeviceRecordDto
{
    [JsonProperty("deviceName")]
    public string? DeviceName { get; init; }
    
    [JsonProperty("value")]
    public double? Value { get; init; }
    
    [JsonProperty("percentage")]
    public double? Percentage { get; set; }
}