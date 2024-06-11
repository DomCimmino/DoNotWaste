using Newtonsoft.Json;

namespace DoNotWaste.Models.AssetScoreModels;

public class Plant
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("plant_type_id")]
    public int PlantTypeId { get; set; }

    [JsonProperty("is_heating")]
    public bool IsHeating { get; set; }

    [JsonProperty("vintage")]
    public int? Vintage { get; set; }

    [JsonProperty("pieces_of_equipment")]
    public int? PiecesOfEquipment { get; set; }

    [JsonProperty("efficiency")]
    public float? Efficiency { get; set; }

    [JsonProperty("capacity")]
    public float? Capacity { get; set; }

    [JsonProperty("condenser_type_id")]
    public int CondenserTypeId { get; set; }

    [JsonProperty("compressor_type_id")]
    public int CompressorTypeId { get; set; }

    [JsonProperty("fuel_type_id")]
    public int FuelTypeId { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }
}