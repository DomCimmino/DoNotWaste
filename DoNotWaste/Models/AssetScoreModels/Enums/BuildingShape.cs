using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DoNotWaste.Models.AssetScoreModels.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum BuildingShape
{
    [JsonProperty("H-shape")]
    HShape,
    
    [JsonProperty("L-shape")]
    LShape,
    
    [JsonProperty("Rectangle")]
    Rectangle,
    
    [JsonProperty("U-shape")]
    UShape
}