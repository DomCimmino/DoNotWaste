namespace DoNotWaste.DTO;

public class DeviceConsumptionDto
{
    public string? DeviceName { get; init; }
    public double? Consumption { get; init; }
    public double? Percentage { get; set; }
}