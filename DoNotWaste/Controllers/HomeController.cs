using System.Diagnostics;
using DoNotWaste.Authentication;
using Microsoft.AspNetCore.Mvc;
using DoNotWaste.Models;
using DoNotWaste.Models.EnergyStarModels;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.Controllers;

public class HomeController(IAssetScoreBuildingService buildingService,IAuthenticationService authenticationService) : Controller
{
    private EnergyStarProperty? Property { get; set; }

    private static MemoryStream? _lastReport;

    public async Task<ActionResult> Index()
    {
        var token = await authenticationService.GetAssetScoreToken();
        var list = await buildingService.GetBuildings();
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Pdf()
    {
        return File(await buildingService.GetReport(31534), "application/pdf", "report.pdf");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}