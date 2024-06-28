using DoNotWaste.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DoNotWaste.Controllers;

public class PortfolioManagerController(PortfolioManagerVm viewmodel) : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
    
    [HttpGet]
    public IActionResult Pdf()
    {
        return File(viewmodel.Report?.ToArray() ?? [], "application/pdf", "report.pdf");
    }

}