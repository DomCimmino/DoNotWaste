using Microsoft.AspNetCore.Mvc;

namespace DoNotWaste.Controllers;

public class PortfolioManagerController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}