using DoNotWaste.Models.EnergyStarModels.Enums;

namespace DoNotWaste.Models.EnergyStarModels;

[XmlRoot(ElementName="timeframe")]
public class EnergyStarTimeframe
{
    [XmlElement(ElementName = "dateRange")]
    public DataRange? DataRange { get; set; }
}

/// <summary>
/// Represents metrics for each property on a monthly, quarterly, or annual interval between a start and end date that you specify.
/// </summary>
[XmlRoot("dateRange")]
public class DataRange
{
    /// <summary>
    /// The date representing the start of the period.
    /// </summary>
    [XmlElement("fromPeriodEndingDate")]
    public PedDate? FromPeriodEndingDate { get; set; }

    /// <summary>
    /// The date representing the end of the period.
    /// </summary>
    [XmlElement("toPeriodEndingDate")]
    public PedDate? ToPeriodEndingDate { get; set; }

    /// <summary>
    /// The interval of the timeframe (monthly, quarterly, or annual).
    /// </summary>
    [XmlElement("interval")]
    public EnergyStarReportingIntervalType Interval { get; set; }
}

public class PedDate
{
    [XmlElement(ElementName = "month")]
    public int Month { get; set; }
    [XmlElement(ElementName = "year")]
    public int Year { get; set; }
}