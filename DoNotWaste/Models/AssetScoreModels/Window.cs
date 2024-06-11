using Newtonsoft.Json;

namespace DoNotWaste.Models.AssetScoreModels;

public class Window
{
    [JsonProperty("id")]
    public int? Id { get; set; }

    [JsonProperty("framing_type_id")]
    public int? FramingTypeId { get; set; }

    [JsonProperty("glass_type_id")]
    public int? GlassTypeId { get; set; }

    [JsonProperty("gas_fill_type_id")]
    public int? GasFillTypeId { get; set; }

    [JsonProperty("shading_type_id")]
    public int? ShadingTypeId { get; set; }

    [JsonProperty("operable")]
    public bool? Operable { get; set; }

    [JsonProperty("window_wall_ratio")]
    public float? WindowWallRatio { get; set; }

    [JsonProperty("window_layout_id")]
    public int? WindowLayoutId { get; set; }

    [JsonProperty("overhang_height_above_window")]
    public float? OverhangHeightAboveWindow { get; set; }

    [JsonProperty("overhang_depth")]
    public float? OverhangDepth { get; set; }

    [JsonProperty("light_shelf_distance_from_top")]
    public float? LightShelfDistanceFromTop { get; set; }

    [JsonProperty("light_shelf_ext_protrusion")]
    public float? LightShelfExtProtrusion { get; set; }

    [JsonProperty("light_shelf_int_protrusion")]
    public float? LightShelfIntProtrusion { get; set; }

    [JsonProperty("fin_depth")]
    public float? FinDepth { get; set; }

    [JsonProperty("edge_fins_only")]
    public bool? EdgeFinsOnly { get; set; }

    [JsonProperty("fin_distance_between")]
    public float? FinDistanceBetween { get; set; }

    [JsonProperty("edge_offset")]
    public float? EdgeOffset { get; set; }

    [JsonProperty("sill_height")]
    public float? SillHeight { get; set; }

    [JsonProperty("window_width")]
    public float? WindowWidth { get; set; }

    [JsonProperty("window_height")]
    public float? WindowHeight { get; set; }

    [JsonProperty("ufactor")]
    public float? Ufactor { get; set; }

    [JsonProperty("shgc")]
    public float? Shgc { get; set; }

    [JsonProperty("vt")]
    public float? Vt { get; set; }

    [JsonProperty("number_of_windows")]
    public int? NumberOfWindows { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}