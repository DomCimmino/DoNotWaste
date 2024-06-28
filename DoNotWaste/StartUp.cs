using DoNotWaste.Authentication;
using DoNotWaste.HttpManager;
using DoNotWaste.Repository;
using DoNotWaste.Repository.Interfaces;
using DoNotWaste.Rest;
using DoNotWaste.Services;
using DoNotWaste.Services.Interfaces;
using DoNotWaste.ViewModels;

namespace DoNotWaste;

public static class StartUp
{
    public static void UpdateConfiguration(this WebApplicationBuilder builder)
    {
        builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets<Configuration>()
            .AddEnvironmentVariables();
    }
    
    public static void RegisterRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IHouseHoldConnectionFactory, HouseHoldConnectionFactory>();
        builder.Services.AddSingleton<IBuildingRepository, BuildingRepository>();
    }
    
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
        builder.Services.AddTransient<IHttpClientFactory, HttpClientFactory>();
        builder.Services.AddTransient<IHttpClient, RestClient>();
        builder.Services.AddTransient<IUserService, UserService>();
        builder.Services.AddTransient<IEnergyStarPropertyService, EnergyStarPropertyService>();
        builder.Services.AddTransient<IEnergyStarMeterService, EnergyStarMeterService>();
        builder.Services.AddTransient<IEnergyStarReportService, EnergyStarReportService>();
        builder.Services.AddTransient<IAssetScoreBuildingService, AssetScoreBuildingService>();
        builder.Services.AddTransient<IChartService, ChartService>();
        builder.Services
            .Configure<Configuration>(builder.Configuration.GetSection(nameof(Configuration)))
            .AddOptions();
    }

    public static void RegisterViewModels(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<HomeVm>();
        builder.Services.AddSingleton<CoSSMicVm>();
        builder.Services.AddSingleton<PortfolioManagerVm>();
    }
}