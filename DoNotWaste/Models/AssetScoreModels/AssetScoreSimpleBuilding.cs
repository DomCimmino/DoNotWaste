using DoNotWaste.Models.AssetScoreModels.Enums;
using Newtonsoft.Json;

namespace DoNotWaste.Models.AssetScoreModels;

public class AssetScoreSimpleBuilding
{
    [JsonProperty("id")]
    public int? Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }
    
    [JsonProperty("city")]
    public string? City { get; set; }
    
    [JsonProperty("year_of_construction")]
    public int? YearOfConstruction { get; set; }
    
    [JsonProperty("reported_floor_area")]
    public int? FloorArea { get; set; }
    
    [JsonProperty("notes")]
    public string? Notes { get; set; }

    [JsonProperty("address")]
    public string? Address { get; set; }
    
    [JsonProperty("number_of_floors")] 
    public string? NumberOfFloors { get; set; }

    [JsonProperty("use_type_name")] 
    public string? UseType { get; } = "Education";
    
    [JsonProperty("predominant_hvac_system_type_name")]
    public HVACType? HcvaSystemType { get; set; }
    
    [JsonProperty("shape_name")] 
    public BuildingShape? BuildingShape { get; set; }
    
    [JsonProperty("state")] 
    public UsCanadaStateProvince? State { get; set; }

    [JsonProperty("zip_code")] 
    public string? ZipCode { get; set; }
}