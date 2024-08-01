namespace DoNotWaste.Models.EnergyStarModels.Enums;

public enum EnergyStarPartnerType
{
    [XmlEnum("Associations")] Associations,
    [XmlEnum("Organizations that Own/Manage/Lease Buildings and Plants")] OrganizationsThatOwnManageLeaseBuildingsAndPlants,
    [XmlEnum("Service and Product Providers")] ServiceAndProductProviders,
    [XmlEnum("Small Businesses")] SmallBusinesses,
    [XmlEnum("Utilities and Energy Efficiency Program Sponsors")] UtilitiesAndEnergyEfficiencyProgramSponsors,
    [XmlEnum("Other")] Other
}