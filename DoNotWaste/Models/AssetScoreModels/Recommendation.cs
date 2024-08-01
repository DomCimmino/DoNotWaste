using Newtonsoft.Json;

namespace DoNotWaste.Models.AssetScoreModels;

public class Recommendation
{
    [JsonProperty("recommendation_id")]
    public string? RecommendationId { get; set; }

    [JsonProperty("recommendation")]
    public string? Advice { get; set; }

    [JsonProperty("cost")]
    public string? Cost { get; set; }

    [JsonProperty("end_use")]
    public string? EndUse { get; set; }

    [JsonProperty("end_use_subcategory")]
    public string? EndUseSubcategory { get; set; }

    [JsonProperty("energy_savings")]
    public string? EnergySavings { get; set; }

    [JsonProperty("upgrade_guide")]
    public string? UpgradeGuide { get; set; }
}