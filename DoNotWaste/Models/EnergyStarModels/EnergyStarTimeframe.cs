using DoNotWaste.Models.EnergyStarModels.Enums;

namespace DoNotWaste.Models.EnergyStarModels;

[XmlRoot(ElementName="timeframe")]
public class EnergyStarTimeframe
{
    [XmlElement(ElementName = "singlePeriod")]
    public SinglePeriod? SinglePeriod { get; set; }
    
}

/// <summary>
/// Represents metrics for each property on a monthly, quarterly, or annual interval between a start and end date that you specify.
/// </summary>
[XmlRoot("dateRange")]
public class SinglePeriod
{
    /// <summary>
    /// The date representing the end of the period.
    /// </summary>
    [XmlElement("periodEndingDate")]
    public PedDate? PeriodEndingDate { get; set; }
}

public class PedDate
{
    [XmlElement(ElementName = "month")]
    public int Month { get; set; }
    [XmlElement(ElementName = "year")]
    public int Year { get; set; }
}