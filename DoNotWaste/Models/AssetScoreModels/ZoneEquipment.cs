using Newtonsoft.Json;

namespace DoNotWaste.Models.AssetScoreModels;

public class ZoneEquipment
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("cooling_zone_equipment_type_id")]
    public int CoolingZoneEquipmentTypeId { get; set; }

    [JsonProperty("heating_zone_equipment_type_id")]
    public int HeatingZoneEquipmentTypeId { get; set; }

    [JsonProperty("heating_plant_id")]
    public int HeatingPlantId { get; set; }

    [JsonProperty("cooling_plant_id")]
    public int CoolingPlantId { get; set; }

    [JsonProperty("fuel_type_id")]
    public int FuelTypeId { get; set; }

    [JsonProperty("heating_pieces_of_equipment")]
    public int HeatingPiecesOfEquipment { get; set; }

    [JsonProperty("heating_efficiency")]
    public float HeatingEfficiency { get; set; }

    [JsonProperty("heating_equipment_vintage")]
    public int HeatingEquipmentVintage { get; set; }

    [JsonProperty("heating_capacity")]
    public float HeatingCapacity { get; set; }

    [JsonProperty("cooling_type_id")]
    public int CoolingTypeId { get; set; }

    [JsonProperty("cooling_efficiency")]
    public float CoolingEfficiency { get; set; }

    [JsonProperty("cooling_pieces_of_equipment")]
    public int CoolingPiecesOfEquipment { get; set; }

    [JsonProperty("cooling_equipment_vintage")]
    public int CoolingEquipmentVintage { get; set; }

    [JsonProperty("has_economizer")]
    public bool HasEconomizer { get; set; }

    [JsonProperty("sink_source_type_id")]
    public int SinkSourceTypeId { get; set; }

    [JsonProperty("heating_vintage")]
    public int HeatingVintage { get; set; }

    [JsonProperty("cooling_vintage")]
    public int CoolingVintage { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }
}