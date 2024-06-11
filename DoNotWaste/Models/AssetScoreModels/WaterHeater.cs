using Newtonsoft.Json;

namespace DoNotWaste.Models.AssetScoreModels;

public class WaterHeater
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("fuel_type_id")]
    public int FuelTypeId { get; set; }

    [JsonProperty("distribution_type_id")]
    public int DistributionTypeId { get; set; }

    [JsonProperty("uses_heat_pump")]
    public bool UsesHeatPump { get; set; }

    [JsonProperty("water_heater_efficiency")]
    public float WaterHeaterEfficiency { get; set; }

    [JsonProperty("tank_insulation_thickness")]
    public float TankInsulationThickness { get; set; }

    [JsonProperty("tank_insulation_r_value")]
    public float TankInsulationRValue { get; set; }

    [JsonProperty("tank_volume")]
    public float TankVolume { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }
}