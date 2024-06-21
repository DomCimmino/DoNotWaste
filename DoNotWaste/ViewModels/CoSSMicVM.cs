using DoNotWaste.DTO;
using DoNotWaste.Models.DataModel;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.ViewModels;

public class CoSSMicVM(IChartService chartService)
{
    public IEnumerable<BuildingTypeDto> BuildingsType => LoadBuildingsType();

    public IEnumerable<BuildingDto> Buildings => LoadBuildings();

    private static IEnumerable<BuildingTypeDto> LoadBuildingsType()
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

    private static IEnumerable<BuildingDto> LoadBuildings()
    {
        var buildings = new List<BuildingDto>();

        foreach (NumberResidentialBuildings numberBuilding in Enum.GetValues(typeof(NumberResidentialBuildings)))
        {
            buildings.Add(new BuildingDto
                { BuildingTypeId = 1, Id = (int?)numberBuilding, Number = Enum.GetName(numberBuilding) });
        }

        foreach (NumberIndustrialBuildings numberBuilding in Enum.GetValues(typeof(NumberIndustrialBuildings)))
        {
            buildings.Add(new BuildingDto
                { BuildingTypeId = 2, Id = (int?)numberBuilding, Number = Enum.GetName(numberBuilding) });
        }

        return buildings;
    }
}