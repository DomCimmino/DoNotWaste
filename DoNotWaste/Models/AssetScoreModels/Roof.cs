using Newtonsoft.Json;

namespace DoNotWaste.Models.AssetScoreModels;

public class Roof
{
    [JsonProperty("id")]
    public int? Id { get; set; }

    [JsonProperty("r_value")]
    public float? RValue { get; set; }
    
    [JsonProperty("insulation_thickness")]
    public string? InsulationThickness { get; set; }

    [JsonProperty("u_factor")]
    public float? UFactor { get; set; }

    [JsonProperty("skylight")]
    public Skylight? Skylight { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}