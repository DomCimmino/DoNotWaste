namespace DoNotWaste.Models.EnergyStarModels;

[XmlRoot(ElementName="contact")]
public class EnergyStarContact { 

    /// <summary>
    /// Your first name
    /// </summary>
    [XmlElement(ElementName="firstName")] 
    public string? FirstName { get; set; } 

    /// <summary>
    /// Your last name
    /// </summary>
    [XmlElement(ElementName="lastName")] 
    public string? LastName { get; set; } 
    
    [XmlElement(ElementName="address")] 
    public EnergyStarAddress? Address { get; set; } 

    /// <summary>
    /// Your email address
    /// </summary>
    [XmlElement(ElementName="email")] 
    public string? Email { get; set; } 

    [XmlElement(ElementName="jobTitle")] 
    public string? JobTitle { get; set; } 

    [XmlElement(ElementName="phone")] 
    public string? Phone { get; set; } 
}