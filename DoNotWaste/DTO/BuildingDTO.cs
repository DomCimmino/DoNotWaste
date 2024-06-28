using Newtonsoft.Json;

namespace DoNotWaste.DTO;

public class BuildingDto
{
    [JsonProperty("id")] 
    public int? Id { get; set; }
    
    [JsonProperty("name")]
    public string? Name { get; set; }
    
    [JsonProperty("number")] 
    public string? Number { get; set; }
    
    [JsonProperty("buildingTypeId")] 
    public int? BuildingTypeId { get; set; }
    
    [JsonProperty("primaryFunction")]
    public string? PrimaryFunction { get; set; }
    
    [JsonProperty("yearBuilt")]
    public int? YearBuilt { get; set; }
    
    [JsonProperty("address")]
    public string? Address { get; set; } = string.Empty;
}