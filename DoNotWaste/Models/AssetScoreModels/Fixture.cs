using Newtonsoft.Json;

namespace DoNotWaste.Models.AssetScoreModels;

public class Fixture
{
    [JsonProperty("id")]
    public int? Id { get; set; }

    [JsonProperty("mounting_type_id")]
    public int? MountingTypeId { get; set; }

    [JsonProperty("lamp_type_id")]
    public int? LampTypeId { get; set; }

    [JsonProperty("uses_percent_served")]
    public bool? UsesPercentServed { get; set; }

    [JsonProperty("percent_served")]
    public float? PercentServed { get; set; }

    [JsonProperty("number_of_lamps")]
    public int? NumberOfLamps { get; set; }

    [JsonProperty("number_of_fixtures")]
    public int? NumberOfFixtures { get; set; }

    [JsonProperty("lamp_wattage")]
    public float? LampWattage { get; set; }

    [JsonProperty("has_daylight_controls")]
    public bool? HasDaylightControls { get; set; }

    [JsonProperty("has_occupancy_controls")]
    public bool? HasOccupancyControls { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }
}