using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DoNotWaste.Models.AssetScoreModels;

public class Block
{
    [JsonProperty("id")]
    public int? Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("shape_id")]
    public int? ShapeId { get; set; }

    [JsonProperty("dimension_1")]
    public float? Dimension1 { get; set; }

    [JsonProperty("dimension_2")]
    public float? Dimension2 { get; set; }

    [JsonProperty("dimension_3")]
    public float? Dimension3 { get; set; }

    [JsonProperty("dimension_4")]
    public float? Dimension4 { get; set; }

    [JsonProperty("dimension_5")]
    public float? Dimension5 { get; set; }

    [JsonProperty("dimension_6")]
    public float? Dimension6 { get; set; }

    [JsonProperty("dimension_7")]
    public float? Dimension7 { get; set; }

    [JsonProperty("dimension_8")]
    public float? Dimension8 { get; set; }

    [JsonProperty("dimension_9")]
    public float? Dimension9 { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonProperty("number_of_floors")]
    public int? NumberOfFloors { get; set; }

    [JsonProperty("number_of_bg_floors")]
    public int? NumberOfBgFloors { get; set; }

    [JsonProperty("floor_to_floor_height")]
    public float? FloorToFloorHeight { get; set; }

    [JsonProperty("has_drop_ceiling")]
    public bool? HasDropCeiling { get; set; }

    [JsonProperty("floor_to_ceiling_height")]
    public float? FloorToCeilingHeight { get; set; }

    [JsonProperty("use_type_id")]
    public int? UseTypeId { get; set; }

    [JsonProperty("has_timer_controls")]
    public bool? HasTimerControls { get; set; }

    [JsonProperty("surfaces")]
    public List<Surface>? Surfaces { get; set; }

    [JsonProperty("roof")]
    public Roof? Roof { get; set; }

    [JsonProperty("floor")]
    public Floor? Floor { get; set; }

    [JsonProperty("fixtures")]
    public List<Fixture>? Fixtures { get; set; }

    [JsonProperty("air_handlers")]
    public List<AirHandler>? AirHandlers { get; set; }

    [JsonProperty("zone_equipment")]
    public List<ZoneEquipment>? ZoneEquipment { get; set; }

    [JsonProperty("operation")]
    public Operation? Operation { get; set; }

    [JsonProperty("water_heaters")]
    public List<WaterHeater>? WaterHeaters { get; set; }
}

public class BlockAirHandler
{
    [JsonProperty("block_id")]
    public int? BlockId { get; set; }
    
    [JsonProperty("air_handler_id")]
    public int? AirHandlerId { get; set; }
}

public class BlockFixture
{
    [JsonProperty("block_id")]
    public int? BlockId { get; set; }

    [JsonProperty("fixture_id")]
    public int? FixtureId { get; set; }

    [JsonProperty("uses_percent_served")]
    public bool? UsesPercentServed { get; set; }

    [JsonProperty("percent_served")]
    public float? PercentServed { get; set; }

    [JsonProperty("number_of_fixtures")]
    public int? NumberOfFixtures { get; set; }

    [JsonProperty("has_daylight_controls")]
    public bool? HasDaylightControls { get; set; }

    [JsonProperty("has_occupancy_controls")]
    public bool? HasOccupancyControls { get; set; }
}

public class BlockWaterHeater
{
    [JsonProperty("block_id")]
    public int? BlockId { get; set; }

    [JsonProperty("water_heater_id")]
    public int? WaterHeaterId { get; set; }
}

public class BlockZoneEquipment
{
    [JsonProperty("block_id")]
    public int? BlockId { get; set; }

    [JsonProperty("zone_equipment_id")]
    public int? ZoneEquipmentId { get; set; }
}