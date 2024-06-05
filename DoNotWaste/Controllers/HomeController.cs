using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DoNotWaste.Models;
using DoNotWaste.Models.DataModel;
using DoNotWaste.Repository.Interfaces;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.Controllers;

public class HomeController(IUserService userService, IBuildingRepository buildingRepository) : Controller
{
    public async Task<ActionResult> Index()
    {
        var account = await userService.GetUser();
        var residential1 = buildingRepository.GetResidential(NumberResidentialBuildings.First);
        var residential2 = buildingRepository.GetResidential(NumberResidentialBuildings.Second);
        var residential3 = buildingRepository.GetResidential(NumberResidentialBuildings.Third);
        var residential4 = buildingRepository.GetResidential(NumberResidentialBuildings.Fourth);
        var residential5 = buildingRepository.GetResidential(NumberResidentialBuildings.Fifth);
        var residential6 = buildingRepository.GetResidential(NumberResidentialBuildings.Sixth);
        var industrial1 = buildingRepository.GetIndustrial(NumberIndustrialBuildings.First);
        var industrial2 = buildingRepository.GetIndustrial(NumberIndustrialBuildings.Second);
        var industrial3 = buildingRepository.GetIndustrial(NumberIndustrialBuildings.Third);
        
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