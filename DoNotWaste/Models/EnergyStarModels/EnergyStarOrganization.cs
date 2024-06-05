using System.ComponentModel.DataAnnotations;
using DoNotWaste.Models.EnergyStarModels.Enums;

namespace DoNotWaste.Models.EnergyStarModels;

[XmlRoot(ElementName="organization")]
public class EnergyStarOrganization { 

    /// <summary>
    /// Your primary business.
    /// Value are in the PrimaryBusiness class
    /// </summary>
    [XmlElement(ElementName="primaryBusiness")] 
    public EnergyStarPrimaryBusiness? PrimaryBusiness { get; set; } 

    /// <summary>
    /// Describes other if you chose other as your primary business.
    /// </summary>
    [XmlElement(ElementName="otherBusinessDescription")] 
    [MinLength(1)]
    [MaxLength(1000)]
    public string? OtherBusinessDescription { get; set; } 

    /// <summary>
    /// Whether organization is an ENERGY STAR Partner.
    /// </summary>
    [XmlElement(ElementName="energyStarPartner")] 
    public bool? EnergyStarPartner { get; set; } 

    /// <summary>
    /// Whether organization is an ENERGY STAR SPP Partner.
    /// Only required if the organization is an ENERGY STAR Partner.
    /// Value are in the EnergyStarPartnerType class
    /// </summary>
    [XmlElement(ElementName="energyStarPartnerType")] 
    public EnergyStarPartnerType? EnergyStarPartnerType { get; set; } 

    /// <summary>
    /// Your Organization's name.
    /// </summary> 
    [XmlAttribute(AttributeName="name")] 
    [MinLength(1)]
    [MaxLength(1000)]
    public string? Name { get; set; } 
}