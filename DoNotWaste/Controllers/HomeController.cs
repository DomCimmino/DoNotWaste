using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DoNotWaste.Models;
using DoNotWaste.ViewModels;

namespace DoNotWaste.Controllers;

public class HomeController(HomeVm viewModel) : Controller
{
    private static MemoryStream? _lastReport;

    public IActionResult Index()
    {
        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Pdf()
    {
        return File(_lastReport?.ToArray() ?? [], "application/pdf", "report.pdf");
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

    [HttpGet]
    public IActionResult Loading()
    {
        Thread.Sleep(3000);
        return Ok(true);
    }
}