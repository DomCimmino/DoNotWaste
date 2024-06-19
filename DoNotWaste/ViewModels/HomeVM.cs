using DoNotWaste.DTO;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.ViewModels;

public class HomeVm(IChartService chartService)
{
    public ChartDataDto ResidentialMeanData => chartService.GetResidentialMeanDataChart();
    
    public ChartDataDto IndustrialMeanData => chartService.GetIndustrialMeanDataChart();
    
}