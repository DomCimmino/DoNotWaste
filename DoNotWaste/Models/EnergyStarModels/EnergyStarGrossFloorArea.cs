using DoNotWaste.Models.EnergyStarModels.Enums;

namespace DoNotWaste.Models.EnergyStarModels;

public class EnergyStarGrossFloorArea
{
    /// <summary>
    /// The total gross floor area of all buildings at the property, measured at the exterior boundary of the enclosing walls, including all areas within the building (common, tenant, maintenance, etc).
    /// </summary>
    [XmlElement(ElementName="value")] 
    public int? Value { get; set; } 

    /// <summary>
    /// The units of the Gross Floor Area (Square Foot or Square Meter).
    /// </summary>
    [XmlAttribute(AttributeName="units")] 
    public EnergyStarGrossFloorAreaUnitsType? Units { get; set; } 

    [XmlAttribute(AttributeName="temporary")] 
    public bool Temporary { get; set; } 
}