using Newtonsoft.Json;

namespace DoNotWaste.DTO;

public class ChartDataDto
{
    [JsonProperty("labels")] 
    public List<string>? Labels { get; set; }
    
    [JsonProperty("data")] 
    public List<double>? Data { get; set; }
}