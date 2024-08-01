namespace DoNotWaste.Models.EnergyStarModels;

public class BaseUseDetails
{
    [XmlElement(ElementName="value")] 
    public int? Value { get; set; } 
    
    [XmlAttribute(AttributeName="temporary")] 
    public bool Temporary { get; set; } 
    
    [XmlAttribute(AttributeName="currentAsOf")] 
    public string? CurrentAsOf { get; set; } 
}