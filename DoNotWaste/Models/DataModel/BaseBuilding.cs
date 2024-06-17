namespace DoNotWaste.Models.DataModel;

public class BaseBuilding
{
    public int Id { get; set; }
    public DateTime FirstDateMeasure => Costant.StartDate;
    public DateTime LastDateMeasure => Costant.EndDate;
}