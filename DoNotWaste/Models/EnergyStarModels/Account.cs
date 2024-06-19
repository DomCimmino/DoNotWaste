using System.ComponentModel.DataAnnotations;
using DoNotWaste.Models.EnergyStarModels;

[XmlRoot(ElementName="account")]
public class Account { 

    /// <summary>
    /// The ID to the account.
    /// This is ignored if specified in a XML request.
    /// This is provided by Portfolio Manager only in a XML response.
    /// </summary>
    [XmlElement(ElementName="id")] 
    public int? Id { get; set; } 

    /// <summary>
    /// Your username.
    /// </summary>
    [XmlElement(ElementName="username")]
    [MinLength(1)]
    [MaxLength(60)]
    public string? Username { get; set; } 

    /// <summary>
    /// Your password.
    /// The password must be at least 8 characters in length and must contain 3 out of  4 of the following requirements:
    /// (i) uppercase characters,
    /// (ii) lowercase characters,
    /// (iii) base 10 digits (0 through 9)
    /// (iv) nonalphanumeric characters: ~!@#$%^&amp;*_-+=`|\(){}[]:;"'&lt;&gt;,.?/
    /// </summary>
    [XmlElement(ElementName="password")]
    [MinLength(8)]
    [MaxLength(120)]
    public string? Password { get; set; } 
    
    /// <summary>
    /// Whether you will be using web services.
    /// </summary>
    [XmlElement(ElementName="webserviceUser")] 
    public bool? WebserviceUser { get; set; } 

    /// <summary>
    /// Whether you want people to be able to search for you.
    /// </summary>
    [XmlElement(ElementName="searchable")] 
    public bool? Searchable { get; set; } 

    /// <summary>
    /// Your saved billboard metric
    /// </summary>
    [XmlElement(ElementName="billboardMetric")] 
    public string? BillboardMetric { get; set; } 
    
    /// <summary>
    /// Value are in LanguagePreference class
    /// </summary>
    [XmlElement(ElementName="languagePreference")] 
    public string? LanguagePreference { get; set; } 

    [XmlElement(ElementName="contact")] 
    public Contact? Contact { get; set; } 

    [XmlElement(ElementName="organization")] 
    public Organization? Organization { get; set; } 

    /// <summary>
    /// Indicates whether properties marked as “Test Properties” in the account will be included in the charts and graphs on My Portfolio page.
    /// </summary>
    [XmlElement(ElementName="includeTestPropertiesInGraphics")] 
    public bool? IncludeTestPropertiesInGraphics { get; set; } 

    /// <summary>
    /// This setting ONLY applies to accounts belonging to Canada.  NRCAN (Natural Resources of Canada) can contact you with training opportunities, tool updates, program news and other information about the ENERGY STAR program.
    /// </summary>
    [XmlElement(ElementName="emailPreferenceCanadianAccount")] 
    public bool? EmailPreferenceCanadianAccount { get; set; } 
}