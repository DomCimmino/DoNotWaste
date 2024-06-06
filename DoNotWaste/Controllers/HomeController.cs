using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DoNotWaste.Models;
using DoNotWaste.Models.EnergyStarModels;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.Controllers;

public class HomeController(
    IUserService userService,
    IEnergyStarPropertyService propertyService) : Controller
{
    private EnergyStarProperty? Property { get; set; }

    public async Task<ActionResult> Index()
    {
        var account = await userService.GetEnergyStarAccount();
        var propertiesResponse = await propertyService.GetPropertiesList(account.Id ?? -1);
        
        Property =
            await propertyService.GetProperty(propertiesResponse.Links?.Link?.FirstOrDefault()?.Id ?? -1);
        Property.Id = propertiesResponse.Links?.Link?.FirstOrDefault()?.Id ?? -1;
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