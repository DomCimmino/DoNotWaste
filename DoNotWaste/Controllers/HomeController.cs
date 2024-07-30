using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DoNotWaste.Models;
using DoNotWaste.ViewModels;

namespace DoNotWaste.Controllers;

public class HomeController(HomeVm viewModel) : Controller
{
    public IActionResult Index()
    {
        return View(viewModel);

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    [HttpGet]
    public IActionResult GetResidentialMeanConsumption()
    {
        return Ok(viewModel.ResidentialMeanData);
    }
    
    [HttpGet]
    public IActionResult GetIndustrialMeanConsumption()
    {
        return Ok(viewModel.IndustrialMeanData);
    }
}