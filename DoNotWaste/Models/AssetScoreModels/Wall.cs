using Newtonsoft.Json;

namespace DoNotWaste.Models.AssetScoreModels;

public class Wall
{
    [JsonProperty("id")]
    public int? Id { get; set; }

    [JsonProperty("wall_type_id")]
    public int? WallTypeId { get; set; }

    [JsonProperty("r_value")]
    public float? RValue { get; set; }

    [JsonProperty("insulation_thickness")]
    public float? InsulationThickness { get; set; }

    [JsonProperty("uf_factor")]
    public float? UfFactor { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonProperty("window")]
    public Window? Window { get; set; }

    // [JsonProperty("points")]
    // public List<Point>? Points { get; set; }
}