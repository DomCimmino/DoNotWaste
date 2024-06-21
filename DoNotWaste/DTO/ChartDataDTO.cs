using Newtonsoft.Json;

namespace DoNotWaste.DTO;

public class ChartDataDto
{
    [JsonProperty("buildingTypeId")] 
    public int? BuildingTypeId { get; set; }
    
    [JsonProperty("buildingTypeName")] 
    public string? BuildingTypeName { get; set; }
    
    [JsonProperty("buildingName")] 
    public string? BuildingName { get; set; }
    
    [JsonProperty("id")]
    public int? Id { get; set; }
    
    [JsonProperty("labels")] 
    public List<string>? Labels { get; set; }
    
    [JsonProperty("data")] 
    public List<double>? Data { get; set; }
}