using System.Collections;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DoNotWaste.Models;
using DoNotWaste.Models.DataModel;
using DoNotWaste.Models.EnergyStarModels;
using DoNotWaste.Models.EnergyStarModels.Enums;
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

    public async Task<ActionResult> Index()
    {
        var account = await userService.GetEnergyStarAccount();
        var propertiesResponse = await propertyService.GetPropertiesList(account.Id ?? -1);
        Property = await propertyService.GetProperty(propertiesResponse.Links?.Link?.FirstOrDefault()?.Id ?? -1);
        var propertyUseListResponse = await propertyService.GetPropertyUseList(Property.Id);
        Property.Consumption = buildingRepository.GetResidential(NumberResidentialBuildings.Fourth);
        var monthlyTotal = ((ResidentialBuilding)Property.Consumption).MonthlyTotal();
        return View();
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