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
    private EnergyStarMeter? EletricMeter { get; set; }
    private EnergyStarMeter? PhotovoltaicMeter { get; set; }

    public async Task<ActionResult> Index()
    {
        var account = await userService.GetEnergyStarAccount();
        var propertiesResponse = await propertyService.GetPropertiesList(account.Id ?? -1);

        Property =
            await propertyService.GetProperty(propertiesResponse.Links?.Link?.FirstOrDefault()?.Id ?? -1);
        Property.Id = propertiesResponse.Links?.Link?.FirstOrDefault()?.Id ?? -1;

        Property.Consumption = buildingRepository.GetResidential(NumberResidentialBuildings.Fourth);

        var meterListResponse = await meterService.GetMeterList(Property.Id);

        foreach (var link in meterListResponse.Links?.Link ?? [])
        {
            var meterResponse = await meterService.GetMeter(link.Id);
            if (meterResponse.Type == EnergyStarMeterType.Electric) EletricMeter = meterResponse;
            else PhotovoltaicMeter = meterResponse;
        }

        var type = typeof(ResidentialBuilding);

        var propertyInfo = type.GetProperties();

        var random = new Random();

        foreach (var property in propertyInfo)
        {
            if (property.GetValue(Property.Consumption) == null) continue;
            if (property.Name.Contains("Consumption") || property.Name.Contains("Import") )
            {
                var createConsumptionData = await meterService.AddMeterData(EletricMeter?.Id ?? -1, new EnergyStarMeterData
                {
                    MeterConsumptions = new List<MeterConsumptionBase>
                    {
                        new()
                        {
                            StartDate = Costant.StartDate.ToString("yyyy-MM-dd"),
                            EndDate = Costant.EndDate.ToString("yyyy-MM-dd"),
                            Usage = (double?)property.GetValue(Property.Consumption),
                        }
                    }
                });
            }else if (property.Name.Contains("Production"))
            {
                var createConsumptionData = await meterService.AddMeterData(PhotovoltaicMeter?.Id ?? -1, new EnergyStarMeterData
                {
                    MeterConsumptions = new List<MeterConsumptionBase>
                    {
                        new()
                        {
                            StartDate = Costant.StartDate.ToString("yyyy-MM-dd"),
                            EndDate = Costant.EndDate.ToString("yyyy-MM-dd"),
                            Usage = (double?)property.GetValue(Property.Consumption),
                            RecOwnership = "Arbitrage",
                            EnergyExportedOffSite = "12",
                            GreenPower = new GreenPower
                            {
                                Value = 100,
                                Sources = new GreenPowerSources
                                {
                                    BiogasPct = 0,
                                    GeothermalPct = 0,
                                    SolarPct = Math.Round((double)property.GetValue(Property.Consumption),2),
                                    BiomassPct = 0,
                                    UnknownPct = 0,
                                    WindPct = 0,
                                    SmallHydroPct = 0,
                                },
                                GenerationLocation = new GenerationLocation
                                {
                                    GenerationPlant = 2
                                }
                            }
                        }
                    }
                });
            }
        }
        
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