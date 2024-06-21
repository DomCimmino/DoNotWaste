using Newtonsoft.Json;

namespace DoNotWaste.DTO;

public class BuildingDto
{
    [JsonProperty("id")] 
    public int? Id { get; set; }
    
    [JsonProperty("number")] 
    public string? Number { get; set; }
    
    [JsonProperty("buildingTypeId")] 
    public int? BuildingTypeId { get; set; }
}