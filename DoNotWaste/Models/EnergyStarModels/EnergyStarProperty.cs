using System.ComponentModel.DataAnnotations;
using DoNotWaste.Models.EnergyStarModels.Enums;

namespace DoNotWaste.Models.EnergyStarModels;

[XmlRoot(ElementName="property")]
public class EnergyStarProperty
{
    [XmlIgnore] 
    public int Id { get; set; }
    
    /// <summary>
    /// The name of the property.
    /// </summary>
    [XmlElement(ElementName="name")] 
    [MinLength(1)]
    [MaxLength(80)]
    public string? Name { get; set; } 

    /// <summary>
    /// The primary function of the building.
    /// </summary>
    [XmlElement(ElementName="primaryFunction")] 
    public EnergyStarPropertyPrimaryFunction PrimaryFunction { get; set; } 

    [XmlElement(ElementName="address")] 
    public EnergyStarAddress? Address { get; set; } 

    /// <summary>
    /// The estimated number of buildings for this property.
    /// </summary>
    [XmlElement(ElementName="numberOfBuildings")] 
    public int NumberOfBuildings { get; set; } 

    /// <summary>
    /// The year the property was built.
    /// </summary>
    [XmlElement(ElementName="yearBuilt")] 
    public int YearBuilt { get; set; } 

    /// <summary>
    /// The construction status (either existing, design or test project).
    /// </summary>
    [XmlElement(ElementName="constructionStatus")] 
    public EnergyStarPropertyConstructionStatusType ConstructionStatus { get; set; } 

    /// <summary>
    /// The Gross Floor Area
    /// </summary>
    [XmlElement(ElementName="grossFloorArea")] 
    public EnergyStarGrossFloorArea? GrossFloorArea { get; set; }

    /// <summary>
    /// The percentage occupancy of the property.
    /// </summary>
    [XmlElement(ElementName="occupancyPercentage")] 
    public int? OccupancyPercentage { get; set; } 

    /// <summary>
    /// Whether the property is federally owned.
    /// </summary>
    [XmlElement(ElementName="isFederalProperty")] 
    public bool? IsFederalProperty { get; set; } 
    
    /// <summary>
    /// Whether the property is institutional property.
    /// </summary>
    [XmlElement(ElementName="isInstitutionalProperty")] 
    public bool? IsInstitutionalProperty { get; set; } 

    /// <summary>
    /// Notes about this property.
    /// </summary>
    [XmlElement(ElementName="notes")]
    [MinLength(1)]
    public string? Notes { get; set; } 

    /// <summary>
    /// Current share level for the user calling the webservice.
    /// </summary>
    [XmlElement(ElementName="accessLevel")] 
    public EnergyStarShareLevelType AccessLevel { get; set; } 

    [XmlElement(ElementName="audit")] 
    public EnergyStarAudit? Audit { get; set; } 
}