using Newtonsoft.Json;

namespace DoNotWaste.Models.AssetScoreModels;

public class AssetScoreBuilding
{
    [JsonProperty("id")]
    public int? Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("year_of_construction")]
    public int? YearOfConstruction { get; set; }

    [JsonProperty("total_floor_area")]
    public float? TotalFloorArea { get; set; }

    [JsonProperty("user_id")]
    public int? UserId { get; set; }

    [JsonProperty("notes")]
    public string? Notes { get; set; }

    [JsonProperty("address")]
    public string? Address { get; set; }

    [JsonProperty("city")]
    public string? City { get; set; }

    [JsonProperty("state")]
    public string? State { get; set; }

    [JsonProperty("zip_code")]
    public int? ZipCode { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonProperty("status_type_id")]
    public int? StatusTypeId { get; set; }

    [JsonProperty("blocks")]
    public List<Block>? Blocks { get; set; }

    [JsonProperty("air_handlers")]
    public List<AirHandler>? AirHandlers { get; set; }

    [JsonProperty("zone_equipment")]
    public List<ZoneEquipment>? ZoneEquipment { get; set; }

    [JsonProperty("water_heaters")]
    public List<WaterHeater>? WaterHeaters { get; set; }

    // [JsonProperty("use_types")]
    // public List<UseType>? UseTypes { get; set; }

    [JsonProperty("roofs")]
    public List<Roof>? Roofs { get; set; }

    [JsonProperty("skylights")]
    public List<Skylight>? Skylights { get; set; }

    [JsonProperty("walls")]
    public List<Wall>? Walls { get; set; }

    [JsonProperty("windows")]
    public List<Window>? Windows { get; set; }

    [JsonProperty("floors")]
    public List<Floor>? Floors { get; set; }

    [JsonProperty("fixtures")]
    public List<Fixture>? Fixtures { get; set; }

    [JsonProperty("plants")]
    public List<Plant>? Plants { get; set; }

    [JsonProperty("operations")]
    public List<Operation>? Operations { get; set; }
}