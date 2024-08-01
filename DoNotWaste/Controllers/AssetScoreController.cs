using DoNotWaste.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DoNotWaste.Controllers;

public class AssetScoreController(AssetScoreVm viewModel) : Controller
{
    public IActionResult Index()
    {
        return View(viewModel);
    }
    
    [HttpGet]
    public async Task<IActionResult> LoadBuildings()
    {
        return Ok(await viewModel.LoadBuildings());
    }
    
    [HttpGet]
    public async Task<IActionResult> LoadBuilding(int buildingId)
    {
        return Ok(await viewModel.LoadBuilding(buildingId));
    }
    
    [HttpGet]
    public async Task<IActionResult> LoadBuildingRecommendations()
    {
        return Ok(await viewModel.LoadBuildingRecommendations());
    }
    
    [HttpGet]
    public async Task<IActionResult> LoadReport()
    {
        return File(await viewModel.LoadReport(), "application/pdf", "report.pdf");
    }
}