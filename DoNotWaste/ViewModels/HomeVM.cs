using DoNotWaste.DTO;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.ViewModels;

public class HomeVm(IChartService chartService)
{
    public ChartDataDto ResidentialMeanData => chartService.GetMeanDataChart();
    public ChartDataDto IndustrialMeanData => chartService.GetMeanDataChart(false);
    public List<DeviceRecordDto> ResidentialDeviceConsumptions =>
        chartService.GetAverageDataProgressBar();
    public List<DeviceRecordDto> IndustrialResidentialDeviceConsumptions =>
        chartService.GetAverageDataProgressBar(false);
}