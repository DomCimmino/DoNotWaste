using DoNotWaste.Models.EnergyStarModels.Enums;

namespace DoNotWaste.Models.EnergyStarModels;

public class EnergyStarGrossFloorArea : BaseUseDetails
{
    /// <summary>
    /// The units of the Gross Floor Area (Square Foot or Square Meter).
    /// </summary>
    [XmlAttribute(AttributeName="units")] 
    public EnergyStarGrossFloorAreaUnitsType Units { get; set; } 
}