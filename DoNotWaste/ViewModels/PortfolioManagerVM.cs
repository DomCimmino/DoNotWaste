using DoNotWaste.DTO;
using DoNotWaste.Models.EnergyStarModels;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.ViewModels;

public class PortfolioManagerVm(
    IUserService userService,
    IEnergyStarPropertyService propertyService,
    IEnergyStarMeterService meterService,
    IEnergyStarReportService reportService)
{
    public int? SelectedPropertyId { get; set; }

    public async Task<List<BuildingDto>> LoadProperties()
    {
        var account = await userService.GetEnergyStarAccount();
        var propertiesResponse = await propertyService.GetPropertiesIdList(account.Id ?? -1);
        if (propertiesResponse.Status != StatusResponse.Ok) return [];
        var propertiesList = new List<BuildingDto>();
        foreach (var link in propertiesResponse.Links?.Link ?? [])
        {
            propertiesList.Add(await propertyService.GetDtoProperty(link.Id));
        }

        return propertiesList;
    }

    public async Task<BuildingDto> LoadProperty(int propertyId)
    {
        return await propertyService.GetDtoProperty(propertyId);
    }

    public async Task<List<MeterDataDto>> LoadPropertyData(int propertyId)
    {
        SelectedPropertyId = propertyId;
        var meterListResponse = await meterService.GetMeterList(propertyId);
        if (meterListResponse.Status != StatusResponse.Ok) return [];
        return await meterService.GetMeterData(meterListResponse.Links?.Link?.FirstOrDefault()?.Id ?? -1, null,
            Costant.StartDate, Costant.EndDate);
    }

    public async Task<byte[]> LoadReport()
    {
        return reportService.CreatePdf(await propertyService.GetProperty(SelectedPropertyId ?? -1), await reportService.GetPropertyMetric(SelectedPropertyId ?? -1));
    }
}