namespace DoNotWaste.Models.DataModel;

public class ConsumptionRecord(DateTime startDate, DateTime endDate, double? consumption)
{
    public DateTime StartDate { get; set; } = startDate;
    public DateTime EndDate { get; set; } = endDate;
    public double? Consumption { get; set; } = consumption;
}