using DoNotWaste.Models.EnergyStarModels.Enums;

namespace DoNotWaste.Models.EnergyStarModels;

/// <summary>
/// A service type used for representing a meter
/// </summary>
[XmlRoot("meter")]
public class EnergyStarMeter
{
    /// <summary>
    /// The id of the meter.
    /// </summary>
    [XmlElement("id")]
    public int? Id { get; set; }

    /// <summary>
    /// The type of meter (i.e. electric, natural gas, PDU, Indoor, etc.).
    /// </summary>
    [XmlElement("type")]
    public EnergyStarMeterType Type { get; set; }

    /// <summary>
    /// The name of the meter.
    /// </summary>
    [XmlElement("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Indicates if the meter is set up to be metered monthly or for bulk delivery.
    /// </summary>
    [XmlElement("metered")]
    public bool? Metered { get; set; } = true;

    /// <summary>
    /// The units that measure the energy for the meter (Kbtu, KWh, Mbtu, MWh, ccf, gallons, etc.).
    /// </summary>
    [XmlElement("unitOfMeasure")]
    public EnergyStarUnitOfMeasure UnitOfMeasure { get; set; }

    /// <summary>
    /// The date of the first bill.
    /// </summary>
    [XmlElement("firstBillDate")]
    public string? FirstBillDate { get; set; }

    /// <summary>
    /// Is this meter in use?
    /// </summary>
    [XmlElement("inUse")]
    public bool? InUse { get; set; }

    /// <summary>
    /// If the meter is no longer in use, this is the date that it went inactive.
    /// </summary>
    [XmlElement("inactiveDate")]
    public string? InactiveDate { get; set; }

    /// <summary>
    /// If the type of meter is "Other," this is the description of the meter's energy type.
    /// </summary>
    [XmlElement("otherDescription")]
    public string? OtherDescription { get; set; }

    /// <summary>
    /// Current share level for the user calling the webservice.
    /// </summary>
    [XmlElement("accessLevel")]
    public EnergyStarShareLevelType AccessLevel { get; set; }

    /// <summary>
    /// If the meter is aggregate meter or not.
    /// </summary>
    [XmlElement("aggregateMeter")]
    public bool? AggregateMeter { get; set; }

    /// <summary>
    /// Audit log information.
    /// </summary>
    [XmlElement("audit")]
    public EnergyStarAudit? Audit { get; set; }
}