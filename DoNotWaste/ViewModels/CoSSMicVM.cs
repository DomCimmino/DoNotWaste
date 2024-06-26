using DoNotWaste.DTO;
using DoNotWaste.Models.DataModel;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.ViewModels;

public class CoSSMicVM(IChartService chartService)
{
    public List<BuildingTypeDto> BuildingsType => LoadBuildingsType();
    public List<BuildingDto> Buildings => LoadBuildings();
    public List<ChartDataDto> ChartData => LoadChartData();

    public List<DeviceRecordDto> GetConsumptionProgressBarData(int buildingTypeId, int? buildingId)
    {
        if (buildingId != null)
        {
            return buildingTypeId == Costant.ResidentialType
                ? chartService.GetSingleBuildingDevicesConsumptionData(
                    (NumberResidentialBuildings)Enum.ToObject(typeof(NumberResidentialBuildings), buildingId))
                : chartService.GetSingleBuildingDevicesConsumptionData(
                    (NumberIndustrialBuildings)Enum.ToObject(typeof(NumberIndustrialBuildings), buildingId));
        }

        return buildingTypeId == Costant.ResidentialType
            ? chartService.GetSumConsumptionDataByType()
            : chartService.GetSumConsumptionDataByType(false);
    }
    
    public double GetPhotovoltaicProduction(int buildingTypeId, int? buildingId)
    {
        if (buildingId != null)
        {
            return buildingTypeId == Costant.ResidentialType
                ? chartService.GetSumProductionDataById(
                    (NumberResidentialBuildings)Enum.ToObject(typeof(NumberResidentialBuildings), buildingId))
                : chartService.GetSumProductionDataById(
                    (NumberIndustrialBuildings)Enum.ToObject(typeof(NumberIndustrialBuildings), buildingId));
        }

        return buildingTypeId == Costant.ResidentialType
            ? chartService.GetSumProductionDataByType()
            : chartService.GetSumProductionDataByType(false);
    }

    private static List<BuildingTypeDto> LoadBuildingsType()
    {
        return
        [
            new BuildingTypeDto
            {
                Name = "Residential",
                Id = 1,
                Icon = "fa-solid fa-house"
            },

            new BuildingTypeDto
            {
                Name = "Industrial",
                Id = 2,
                Icon = "fa-solid fa-industry"
            }
        ];
    }

    private static List<BuildingDto> LoadBuildings()
    {
        var buildings =
            (from NumberResidentialBuildings numberBuilding in Enum.GetValues(typeof(NumberResidentialBuildings))
                select new BuildingDto
                    { BuildingTypeId = 1, Id = (int?)numberBuilding, Number = Enum.GetName(numberBuilding) }).ToList();

        buildings.AddRange(
            from NumberIndustrialBuildings numberBuilding in Enum.GetValues(typeof(NumberIndustrialBuildings))
            select new BuildingDto
                { BuildingTypeId = 2, Id = (int?)numberBuilding, Number = Enum.GetName(numberBuilding) });

        return buildings;
    }

    private List<ChartDataDto> LoadChartData()
    {
        var chartData =
            (from NumberResidentialBuildings numberBuilding in Enum.GetValues(typeof(NumberResidentialBuildings))
                select chartService.GetSingleBuildingDataChart(numberBuilding)).ToList();
        chartData.AddRange(
            from NumberIndustrialBuildings numberBuilding in Enum.GetValues(typeof(NumberIndustrialBuildings))
            select chartService.GetSingleBuildingDataChart(numberBuilding));

        return chartData;
    }
}