using DoNotWaste.DTO;
using DoNotWaste.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DoNotWaste.Controllers;

public class CoSSMicController(CoSSMicVm viewModel) : Controller
{
    public IActionResult Index()
    {
        return View(viewModel);
    }

    [HttpGet]
    public IActionResult GetBuildingsByType(int? buildingTypeId)
    {
        var result = buildingTypeId == null
            ? viewModel.Buildings
            : viewModel.Buildings.Where(b => b.BuildingTypeId == buildingTypeId).ToList();

        return Ok(result);
    }

    [HttpGet]
    public IActionResult GetBuildingDataChart(int? buildingTypeId, int? buildingNumberId)
    {
        return buildingTypeId == null
            ? Ok(viewModel.ChartData)
            : Ok(buildingNumberId == null
                ? viewModel.ChartData.Where(x => x.BuildingTypeId == buildingTypeId)
                : viewModel.ChartData.Where(x => x.BuildingTypeId == buildingTypeId && x.Id == buildingNumberId));
    }

    [HttpGet]
    public IActionResult GetDeviceConsumptionData(int? buildingTypeId, int? buildingNumberId)
    {
        return buildingTypeId == null
            ? Ok(new List<DeviceRecordDto>())
            : Ok(buildingNumberId == null
                ? viewModel.GetConsumptionProgressBarData(buildingTypeId ?? -1, null)
                : viewModel.GetConsumptionProgressBarData(buildingTypeId ?? -1, buildingNumberId));
    }

    [HttpGet]
    public IActionResult GetSourceDataEnergy(int? buildingTypeId, int? buildingNumberId)
    {
        return buildingTypeId == null
            ? Ok(new List<double>())
            : Ok(buildingNumberId == null
                ? viewModel.GetSourceDataEnergy((int)buildingTypeId, null)
                : viewModel.GetSourceDataEnergy((int)buildingTypeId, buildingNumberId));
    }
}