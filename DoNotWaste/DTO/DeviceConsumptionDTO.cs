namespace DoNotWaste.DTO;

public class DeviceConsumptionDto
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? DeviceName { get; set; }
    public double? Consumption { get; init; }
    public double? Percentage { get; set; }
}