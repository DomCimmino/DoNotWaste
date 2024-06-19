using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DoNotWaste.Models;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.Controllers;

public class HomeController(IChartService chartService) : Controller
{
    private static MemoryStream? _lastReport;

    public IActionResult Index()
    {
        return View();
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
        var chartData = chartService.GetResidentialMeanDataChart();
        return Ok(chartData);
    }
    
    [HttpGet]
    public IActionResult GetIndustrialMeanConsumption()
    {
        var chartData = chartService.GetIndustrialMeanDataChart();
        return Ok(chartData);
    }
}