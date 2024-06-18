using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DoNotWaste.Models;
using DoNotWaste.Models.DataModel;
using DoNotWaste.Models.EnergyStarModels;
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
    
    [HttpPost]
    public List<object> GetResidentialMeanConsumption()
    {
        var data = new List<object>();
        var chartData = chartService.GetResidentialMeanDataChart();
        data.Add(chartData.Labels);
        data.Add(chartData.Data);
        return data;
    }
    
    [HttpPost]
    public List<object> GetIndustrialMeanConsumption()
    {
        var data = new List<object>();
        var chartData = chartService.GetIndustrialMeanDataChart();
        data.Add(chartData.Labels);
        data.Add(chartData.Data);
        return data;
    }
}