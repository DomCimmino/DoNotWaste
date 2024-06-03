using DoNotWaste.Repository.Interfaces;

namespace DoNotWaste.Repository;

public static class BuilderRepository
{
    public static WebApplicationBuilder RegisterRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IHouseHoldConnectionFactory, HouseHoldConnectionFactory>();
        return builder;
    }
}