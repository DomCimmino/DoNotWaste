namespace DoNotWaste.DTO;

public class DeviceConsumptionDto
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? DeviceName { get; set; }
    public double? TotalConsumption { get; init; }
}