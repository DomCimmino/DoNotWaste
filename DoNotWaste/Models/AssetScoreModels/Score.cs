using Newtonsoft.Json;

namespace DoNotWaste.Models.AssetScoreModels;

public class Score
{
    [JsonProperty("current_score")]
    public int CurrentScore { get; set; }

    [JsonProperty("current_source_eui")]
    public float? CurrentSourceEui { get; set; }

    [JsonProperty("potential_score")]
    public int? PotentialScore { get; set; }

    [JsonProperty("potential_source_eui")]
    public float? PotentialSourceEui { get; set; }

    [JsonProperty("reference_score")]
    public int? ReferenceScore { get; set; }

    [JsonProperty("reference_source_eui")]
    public float? ReferenceSourceEui { get; set; }
}