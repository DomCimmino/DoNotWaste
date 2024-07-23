using Microsoft.AspNetCore.Mvc;

namespace DoNotWaste.Controllers;

public class AssetScoreController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}