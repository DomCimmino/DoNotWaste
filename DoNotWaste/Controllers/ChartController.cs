using DoNotWaste.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoNotWaste.Controllers;

public class ChartController(IChartService chartService) : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ShowChart()
    {
        return View();
    }

    [HttpPost]
    public List<object> GetConsumption()
    {
        var data = new List<object>();
        var chartData = chartService.GetDataChart();
        data.Add(chartData.Labels);
        data.Add(chartData.Data);
        return data;
    }
}