namespace DoNotWaste.Models.DataModel;

public class BaseBuilding
{
    public int Id { get; set; }
    public DateTime FirstDateMeasure { get; } = DateTime.Parse("2016-05-01T00:00:00Z");
    public DateTime LastDateMeasure{ get; } = DateTime.Parse("2017-05-01T00:00:00Z");
}