using Newtonsoft.Json;

namespace DoNotWaste.Models.AssetScoreModels;

public class Floor
{
    [JsonProperty("r_value")]
    public float? RValue { get; set; }

    [JsonProperty("insulation_thickness")]
    public float? InsulationThickness { get; set; }

    [JsonProperty("u_factor")]
    public float? UFactor { get; set; }

    [JsonProperty("has_carpet")]
    public bool? HasCarpet { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }
}