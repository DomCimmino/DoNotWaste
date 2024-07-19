using DoNotWaste.DTO;
using DoNotWaste.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DoNotWaste.Controllers;

public class PortfolioManagerController(PortfolioManagerVm viewmodel) : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> LoadProperties()
    {
        return Ok(await viewmodel.LoadProperties());
    }
    
    [HttpGet]
    public async Task<IActionResult> LoadProperty(int? propertyId)
    {
        return Ok(propertyId != null ? await viewmodel.LoadProperty(propertyId ?? -1) : new BuildingDto());
    }

    [HttpGet]
    public async Task<IActionResult> LoadPropertyData(int? propertyId)
    {
        return Ok(propertyId != null ? await viewmodel.LoadPropertyData(propertyId ?? -1) : []);
    }
    
    [HttpGet]
    public async Task<IActionResult> LoadReport()
    {
        return File(await viewmodel.LoadReport(), "application/pdf", "report.pdf");
    }
}