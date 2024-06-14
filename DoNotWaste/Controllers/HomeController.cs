using System.Diagnostics;
using DoNotWaste.Authentication;
using Microsoft.AspNetCore.Mvc;
using DoNotWaste.Models;
using DoNotWaste.Models.EnergyStarModels;

namespace DoNotWaste.Controllers;

public class HomeController(IAuthenticationService authenticationService) : Controller
{
    private EnergyStarProperty? Property { get; set; }

    private static MemoryStream? _lastReport;

    public async Task<ActionResult> Index()
    {
        var token = await authenticationService.GetAssetScoreToken();
        return View();
    }

    [HttpGet]
    public IActionResult Pdf()
    {
        return File(_lastReport?.ToArray() ?? [], "application/pdf", "report.pdf");
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