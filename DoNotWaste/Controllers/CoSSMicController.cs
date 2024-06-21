using DoNotWaste.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DoNotWaste.Controllers;

public class CoSSMicController(CoSSMicVM viewModel) : Controller
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
}