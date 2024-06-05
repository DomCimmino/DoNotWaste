using System.ComponentModel.DataAnnotations;
using DoNotWaste.Models.EnergyStarModels.Enums;

namespace DoNotWaste.Models.EnergyStarModels;

[XmlRoot(ElementName = "address")]
public class EnergyStarAddress
{
    [XmlAttribute(AttributeName = "address1")]
    [Required]
    [MinLength(1)]
    [MaxLength(100)]
    public string? FirstAddress { get; set; }
    
    [XmlAttribute(AttributeName = "address2")]
    [MinLength(1)]
    [MaxLength(100)]
    public string? SecondAddress{ get; set; }

    [XmlAttribute(AttributeName = "city")] 
    [Required]
    [MinLength(1)]
    [MaxLength(100)]
    public string? City { get; set; }

    [XmlAttribute(AttributeName = "state")]
    public UsCanadaStateProvince UsCanadaStateProvince { get; set; }
    
    [XmlAttribute(AttributeName = "otherState")]
    [MinLength(1)]
    [MaxLength(50)]
    public string? OtherState { get; set; }

    [XmlAttribute(AttributeName = "postalCode")]
    [MinLength(1)]
    [MaxLength(20)]
    public string? PostalCode { get; set; }

    [XmlAttribute(AttributeName = "country")]
    [Required]
    public Countries Country { get; set; }
}