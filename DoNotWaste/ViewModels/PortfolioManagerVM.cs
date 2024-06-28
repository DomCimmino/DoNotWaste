using DoNotWaste.DTO;
using DoNotWaste.Models.EnergyStarModels;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.ViewModels;

public class PortfolioManagerVm(IUserService userService,IEnergyStarPropertyService propertyService)
{
    public MemoryStream? Report { get; set; }

    public async Task<List<BuildingDto>> LoadProperties()
    {
        var propertiesList = new List<BuildingDto>();
        var account = await userService.GetEnergyStarAccount();
        var propertiesResponse = await propertyService.GetPropertiesIdList(account.Id ?? -1);
        if (propertiesResponse.Status != StatusResponse.Ok) return propertiesList;
        foreach (var link in propertiesResponse.Links?.Link ?? [])   
        {
            propertiesList.Add(await propertyService.GetProperty(link.Id));
        }
        return propertiesList;
    }
}