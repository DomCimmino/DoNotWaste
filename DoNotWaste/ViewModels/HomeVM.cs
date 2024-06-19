using DoNotWaste.DTO;
using DoNotWaste.Models.DataModel;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.ViewModels;

public class HomeVm(IChartService chartService)
{
    public ChartDataDto ResidentialMeanData => chartService.GetResidentialMeanDataChart();
    
    public ChartDataDto IndustrialMeanData => chartService.GetIndustrialMeanDataChart();
    public List<DeviceConsumptionDto> ResidentialDeviceConsumptions =>
        chartService.GetResidentialDataProgressBar(NumberResidentialBuildings.Fourth);
    public List<DeviceConsumptionDto> IndustrialResidentialDeviceConsumptions =>
        chartService.GetIndustrialDataProgressBar(NumberIndustrialBuildings.Third);
}