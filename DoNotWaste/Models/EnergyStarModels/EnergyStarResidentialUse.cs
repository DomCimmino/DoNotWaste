using System.ComponentModel.DataAnnotations;

namespace DoNotWaste.Models.EnergyStarModels;

[XmlRoot("singleFamilyHome")]
public class EnergyStarResidentialUse
{
    [XmlElement("name")]
    [MinLength(1)]
    [MaxLength(500)]
    public string? Name { get; set; }
    
    [XmlElement("useDetails")] 
    public List<UseDetail>? UseDetails { get; set; }
}

public class UseDetail
{
    [XmlElement("totalGrossFloorArea")] 
    public EnergyStarGrossFloorArea? TotalGrossFloorArea { get; set; }

    [XmlElement("numberOfBedrooms")]
    public BaseUseDetails? NumberOfBedrooms { get; set; }
    
    [XmlElement("numberOfPeople")]
    public BaseUseDetails? NumberOfPeople { get; set; }
}