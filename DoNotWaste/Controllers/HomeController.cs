using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DoNotWaste.Models;
using DoNotWaste.Repository.Interfaces;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.Controllers;

public class HomeController(IUserService userService, IBuildingRepository buildingRepository) : Controller
{
    public async Task<ActionResult> Index()
    {
        var account = await userService.GetUser();
        var residential = buildingRepository.GetResidential(1);
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