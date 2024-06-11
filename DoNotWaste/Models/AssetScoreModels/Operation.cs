using Newtonsoft.Json;

namespace DoNotWaste.Models.AssetScoreModels;

public class Operation
{
    [JsonProperty("id")]
    public int? Id { get; set; }

    [JsonProperty("misc_electric_load")]
    public float? MiscElectricLoad { get; set; }

    [JsonProperty("misc_gas_load")]
    public float? MiscGasLoad { get; set; }

    [JsonProperty("weekdays_open")]
    public bool? WeekdaysOpen { get; set; }

    [JsonProperty("weekday_open_time")]
    public string? WeekdayOpenTime { get; set; }

    [JsonProperty("weekday_close_time")]
    public string? WeekdayCloseTime { get; set; }

    [JsonProperty("weekends_open")]
    public bool? WeekendsOpen { get; set; }

    [JsonProperty("weekend_open_time")]
    public string? WeekendOpenTime { get; set; }

    [JsonProperty("weekend_close_time")]
    public string? WeekendCloseTime { get; set; }

    [JsonProperty("total_occupants")]
    public int? TotalOccupants { get; set; }

    [JsonProperty("setpoint_heating")]
    public int? SetPointHeating { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}