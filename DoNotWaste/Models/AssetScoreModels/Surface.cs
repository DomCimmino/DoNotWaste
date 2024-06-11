using Newtonsoft.Json;

namespace DoNotWaste.Models.AssetScoreModels;

public class Surface
{
    [JsonProperty("id")]
    public int? Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("type")]
    public string? Type { get; set; }

    [JsonProperty("description")]
    public string? Description { get; set; }

    [JsonProperty("vertices")]
    public string? Vertices { get; set; }

    [JsonProperty("block_id")]
    public int? BlockId { get; set; }

    [JsonProperty("edge_fins_only")]
    public bool? EdgeFinsOnly { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonProperty("edge_offset")]
    public float? EdgeOffset { get; set; }

    [JsonProperty("fin_depth")]
    public float? FinDepth { get; set; }

    [JsonProperty("fin_distance_between")]
    public float? FinDistanceBetween { get; set; }

    [JsonProperty("height")]
    public float? Height { get; set; }

    [JsonProperty("width")]
    public float? Width { get; set; }

    [JsonProperty("light_shelf_distance_from_top")]
    public float? LightShelfDistanceFromTop { get; set; }

    [JsonProperty("light_shelf_ext_protrusion")]
    public float? LightShelfExtProtrusion { get; set; }

    [JsonProperty("light_shelf_int_protrusion")]
    public float? LightShelfIntProtrusion { get; set; }

    [JsonProperty("number_of_windows")]
    public int? NumberOfWindows { get; set; }

    [JsonProperty("overhang_depth")]
    public float? OverhangDepth { get; set; }

    [JsonProperty("overhang_height_above_window")]
    public float? OverhangHeightAboveWindow { get; set; }

    [JsonProperty("shading_type_id")]
    public int? ShadingTypeId { get; set; }

    [JsonProperty("sill_height")]
    public float? SillHeight { get; set; }

    [JsonProperty("wall_id")]
    public int? WallId { get; set; }

    [JsonProperty("window_id")]
    public int? WindowId { get; set; }

    [JsonProperty("window_layout_id")]
    public int? WindowLayoutId { get; set; }

    [JsonProperty("window_width")]
    public float? WindowWidth { get; set; }

    [JsonProperty("window_height")]
    public float? WindowHeight { get; set; }

    [JsonProperty("window_wall_ratio")]
    public float? WindowWallRatio { get; set; }
}