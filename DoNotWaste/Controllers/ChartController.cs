using Microsoft.AspNetCore.Mvc;

namespace DoNotWaste.Controllers;

public class ChartController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ShowChart()
    {
        return View();
    }
}