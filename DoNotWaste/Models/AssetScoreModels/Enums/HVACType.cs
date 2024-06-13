using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DoNotWaste.Models.AssetScoreModels.Enums;


[JsonConverter(typeof(StringEnumConverter))]
public enum HVACType
{
    [JsonProperty("Four Pipe Fan Coil Unit")]
    FourPipeFanCoilUnit,
    
    [JsonProperty("Packaged Terminal Air Conditioner")]
    PackagedTerminalAirConditioner,
    
    [JsonProperty("Packaged Terminal Heat Pump")]
    PackagedTerminalHeatPump,
    
    [JsonProperty("Packaged VAV with Electric Reheat")]
    PackagedVAVWithElectricReheat,
    
    [JsonProperty("Packaged VAV with Hot Water Reheat")]
    PackagedVAVWithHotWaterReheat,
    
    [JsonProperty("Rooftop Air Conditioner and Gas Furnace")]
    RooftopAirConditionerAndGasFurnace,
    
    [JsonProperty("Rooftop Air Source Heat Pump")]
    RooftopAirSourceHeatPump,
    
    [JsonProperty("VAV with Electric Reheat")]
    VAVWithElectricReheat,
    
    [JsonProperty("VAV with Hot Water Reheat")]
    VAVWithHotWaterReheat,
    
    [JsonProperty("VRF")]
    VRF,
    
    [JsonProperty("Warm Air Furnace")]
    WarmAirFurnace,
    
    [JsonProperty("Water Loop Heat Pump")]
    WaterLoopHeatPump,
    
    [JsonProperty("Window AC + Baseboard")]
    WindowACBaseboard
}