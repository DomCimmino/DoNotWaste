using Newtonsoft.Json;

namespace DoNotWaste.DTO;

public class MeterDataDto
{
    [JsonProperty("startDate")]
    public string? StartDate { get; set; }
    
    [JsonProperty("endDate")]
    public string? EndDate { get; set; }
    
    [JsonProperty("cost")]
    public double? Cost { get; set; }
    
    [JsonProperty("usage")]
    public double? Usage { get; set; }
}