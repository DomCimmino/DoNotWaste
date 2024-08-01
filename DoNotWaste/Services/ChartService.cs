using System.Globalization;
using DoNotWaste.DTO;
using DoNotWaste.Models.DataModel;
using DoNotWaste.Repository.Interfaces;
using DoNotWaste.Services.Interfaces;
using DateTime = System.DateTime;

namespace DoNotWaste.Services;

public class ChartService(IBuildingRepository buildingRepository) : IChartService
{
    private readonly CultureInfo _cultureInfo = new("en-US");

    public ChartDataDto GetSingleBuildingDataChart<T>(T numberBuilding) where T : Enum
    {
        var labels = new List<string>();
        var data = new List<double>();
        var building = new BaseBuilding();
        var chartData = new ChartDataDto();

        if (typeof(T) == typeof(NumberResidentialBuildings))
        {
            var number = (NumberResidentialBuildings)(object)numberBuilding;
            building = buildingRepository.GetResidential(number);
            chartData.BuildingTypeId = 1;
            chartData.BuildingTypeName = "Residential";
            chartData.Id = (int?)number;
            chartData.BuildingName = Enum.GetName(number);
        }
        else if (typeof(T) == typeof(NumberIndustrialBuildings))
        {
            var number = (NumberIndustrialBuildings)(object)numberBuilding;
            building = buildingRepository.GetIndustrial((NumberIndustrialBuildings)(object)numberBuilding);
            chartData.BuildingTypeId = 2;
            chartData.BuildingTypeName = "Industrial";
            chartData.Id = (int?)number;
            chartData.BuildingName = Enum.GetName(number);
        }

        foreach (var item in building.MonthlyTotal())
        {
            labels.Add(item.StartDate.ToString("MMMM yyyy", _cultureInfo));
            data.Add(item.Value ?? 0);
        }

        chartData.Labels = labels;
        chartData.Data = data;
        return chartData;
    }

    public List<DeviceRecordDto> GetSingleBuildingDevicesConsumptionData<T>(T numberBuilding) where T : Enum
    {
        if (typeof(T) == typeof(NumberResidentialBuildings))
        {
            var number = (NumberResidentialBuildings)(object)numberBuilding;
            var building = buildingRepository.GetResidential(number);
            return buildingRepository.GetSingleBuildingDevicesConsumptions(building);
        }
        else
        {
            var number = (NumberIndustrialBuildings)(object)numberBuilding;
            var building = buildingRepository.GetIndustrial(number);
            return buildingRepository.GetSingleBuildingDevicesConsumptions(building);
        }
    }

    public ChartDataDto GetMeanDataChart(bool isResidential = true)
    {
        return isResidential
            ? GetMeanDataChart<NumberResidentialBuildings>(buildingRepository.GetResidential)
            : GetMeanDataChart<NumberIndustrialBuildings>(buildingRepository.GetIndustrial);
    }

    public List<DeviceRecordDto> GetAverageDataProgressBar(bool isResidential = true)
    {
        return buildingRepository
            .CalculateDeviceConsumptionsForAllBuildings(isResidential);
    }

    public List<DeviceRecordDto> GetSumConsumptionDataByType(bool isResidential = true)
    {
        return buildingRepository
            .CalculateDeviceConsumptionsForAllBuildings(isResidential, false);
    }

    public double GetSumProductionDataByType(bool isResidential = true)
    {
        return isResidential
            ? buildingRepository.GetBuildingTypePhotovoltaicProduction().Sum(x => x.Value) ?? 0
            : buildingRepository.GetBuildingTypePhotovoltaicProduction(false).Sum(x => x.Value) ?? 0;
    }
    
    public double GetSumProductionDataById<T>(T numberBuilding) where T : Enum
    {
        if (typeof(T) == typeof(NumberResidentialBuildings))
        {
            var number = (NumberResidentialBuildings)(object)numberBuilding;
            var building = buildingRepository.GetResidential(number);
            return buildingRepository.GetSingleBuildingPhotovoltaicProduction(building).Sum(x => x.Value) ?? 0;
        }
        else
        {
            var number = (NumberIndustrialBuildings)(object)numberBuilding;
            var building = buildingRepository.GetIndustrial(number);
            return buildingRepository.GetSingleBuildingPhotovoltaicProduction(building).Sum(x => x.Value) ?? 0;
        }
    }

    private ChartDataDto GetMeanDataChart<T>(Func<T, BaseBuilding> getBuildingFunc) where T : Enum
    {
        var allMonthlyTotal = new List<Record>();
        var labels = new List<string>();
        var data = new List<double>();

        foreach (T number in Enum.GetValues(typeof(T)))
        {
            var building = getBuildingFunc(number);
            allMonthlyTotal.AddRange(building.MonthlyTotal());
        }

        var monthlyDictionaryDivision = new Dictionary<DateTime, List<Record>>();

        foreach (var item in allMonthlyTotal)
        {
            if (!monthlyDictionaryDivision.TryGetValue(item.StartDate, out var list))
            {
                list = new List<Record>();
                monthlyDictionaryDivision[item.StartDate] = list;
            }

            list.Add(item);
        }

        foreach (var startDate in monthlyDictionaryDivision.Keys.OrderBy(d => d))
        {
            labels.Add(startDate.ToString("MMM. yy", _cultureInfo));
            data.Add(monthlyDictionaryDivision[startDate].Average(x => x.Value ?? 0));
        }

        return new ChartDataDto { Labels = labels, Data = data };
    }
}