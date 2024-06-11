using Newtonsoft.Json;

namespace DoNotWaste.Models.AssetScoreModels;

public class Skylight
{
    [JsonProperty("id")]
    public int? Id { get; set; }

    [JsonProperty("ufactor")]
    public float? Ufactor { get; set; }

    [JsonProperty("shgc")]
    public float? Shgc { get; set; }

    [JsonProperty("vt")]
    public float? Vt { get; set; }

    [JsonProperty("percent_footprint")]
    public float? PercentFootprint { get; set; }

    [JsonProperty("skylight_layout_id")]
    public int? SkylightLayoutId { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}