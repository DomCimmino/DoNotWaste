using DoNotWaste.Authentication;
using DoNotWaste.HttpManager;
using DoNotWaste.Repository;
using DoNotWaste.Repository.Interfaces;
using DoNotWaste.Rest;
using DoNotWaste.Services;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste;

public static class StartUp
{
    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
        builder.Services.AddTransient<IHttpClientFactory, HttpClientFactory>();
        builder.Services.AddTransient<IHttpClient, RestClient>();
        builder.Services.AddTransient<IUserService, UserService>();
        builder.Services.AddTransient<IEnergyStarPropertyService, EnergyStarPropertyService>();
        builder.Services
            .Configure<Configuration>(builder.Configuration.GetSection(nameof(Configuration)))
            .AddOptions();
        return builder;
    }

    public static WebApplicationBuilder UpdateConfiguration(this WebApplicationBuilder builder)
    {
        builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets<Configuration>()
            .AddEnvironmentVariables();

        return builder;
    }
    
    public static WebApplicationBuilder RegisterRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IHouseHoldConnectionFactory, HouseHoldConnectionFactory>();
        builder.Services.AddSingleton<IBuildingRepository, BuildingRepository>();
        return builder;
    }
}