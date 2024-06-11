using Newtonsoft.Json;

namespace DoNotWaste.Models.AssetScoreModels;

public class AirHandler
{
     [JsonProperty("id")]
    public int? Id { get; set; }

    [JsonProperty("cooling_air_handler_type_id")]
    public int? CoolingAirHandlerTypeId { get; set; }

    [JsonProperty("heating_air_handler_type_id")]
    public int? HeatingAirHandlerTypeId { get; set; }

    [JsonProperty("heating_plant_id")]
    public int? HeatingPlantId { get; set; }

    [JsonProperty("cooling_plant_id")]
    public int? CoolingPlantId { get; set; }

    [JsonProperty("distribution_type_id")]
    public int? DistributionTypeId { get; set; }

    [JsonProperty("fuel_type_id")]
    public int? FuelTypeId { get; set; }

    [JsonProperty("heating_pieces_of_equipment")]
    public int? HeatingPiecesOfEquipment { get; set; }

    [JsonProperty("heating_efficiency")]
    public float? HeatingEfficiency { get; set; }

    [JsonProperty("heating_equipment_vintage")]
    public int? HeatingEquipmentVintage { get; set; }

    [JsonProperty("cooling_type_id")]
    public int? CoolingTypeId { get; set; }

    [JsonProperty("cooling_efficiency")]
    public float? CoolingEfficiency { get; set; }

    [JsonProperty("cooling_pieces_of_equipment")]
    public int? CoolingPiecesOfEquipment { get; set; }

    [JsonProperty("cooling_capacity")]
    public float? CoolingCapacity { get; set; }

    [JsonProperty("cooling_equipment_vintage")]
    public int? CoolingEquipmentVintage { get; set; }

    [JsonProperty("has_economizer")]
    public bool? HasEconomizer { get; set; }

    [JsonProperty("sink_source_type_id")]
    public int? SinkSourceTypeId { get; set; }

    [JsonProperty("fan_efficiency")]
    public float? FanEfficiency { get; set; }

    [JsonProperty("fan_motor_efficiency")]
    public float? FanMotorEfficiency { get; set; }

    [JsonProperty("fan_control_id")]
    public int? FanControlId { get; set; }

    [JsonProperty("heating_vintage")]
    public int? HeatingVintage { get; set; }

    [JsonProperty("cooling_vintage")]
    public int? CoolingVintage { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }
}