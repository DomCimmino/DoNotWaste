using DoNotWaste.Models.DataModel;

namespace DoNotWaste.Repository.Interfaces;

public interface IBuildingRepository
{
    ResidentialBuilding GetResidential(NumberResidentialBuildings residentialNumber);
    IndustrialBuilding GetIndustrial(NumberIndustrialBuildings industrialNumber);
}