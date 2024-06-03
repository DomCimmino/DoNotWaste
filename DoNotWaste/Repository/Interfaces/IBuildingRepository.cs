using DoNotWaste.Models.DataModel;

namespace DoNotWaste.Repository.Interfaces;

public interface IBuildingRepository
{
    ResidentialBuilding GetResidential(int residentialNumber);
}