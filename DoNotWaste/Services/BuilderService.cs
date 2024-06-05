using DoNotWaste.Authentication;
using DoNotWaste.HttpManager;
using DoNotWaste.Rest;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.Services;

public static class BuilderService
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
}