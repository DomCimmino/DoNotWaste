namespace DoNotWaste.Models.DataModel;

public class Record(DateTime startDate, DateTime endDate, double? value)
{
    public DateTime StartDate { get; set; } = startDate;
    public DateTime EndDate { get; set; } = endDate;
    public double? Value { get; set; } = value;
}