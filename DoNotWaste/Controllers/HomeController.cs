using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DoNotWaste.Models;
using DoNotWaste.Models.DataModel;
using DoNotWaste.Models.EnergyStarModels;
using DoNotWaste.Repository.Interfaces;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.Controllers;

public class HomeController(
    IUserService userService,
    IBuildingRepository buildingRepository,
    IEnergyStarPropertyService propertyService,
    IEnergyStarMeterService meterService,
    IEnergyStarReportService reportService) : Controller
{
    private EnergyStarProperty? Property { get; set; }

    private static MemoryStream? _lastReport;

    public async Task<ActionResult> Index()
    {
        var account = await userService.GetEnergyStarAccount();
        var propertiesResponse = await propertyService.GetPropertiesList(account.Id ?? -1);
        Property = await propertyService.GetProperty(propertiesResponse.Links?.Link?.FirstOrDefault()?.Id ?? -1);
        Property.Consumption = buildingRepository.GetResidential(NumberResidentialBuildings.Fourth);

        _lastReport = reportService.CreatePdf(Property, await reportService.GetPropertyMetric(Property.Id));
        
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