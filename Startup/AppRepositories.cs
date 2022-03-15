using jwt_implement.Repositories;

namespace jwt_implement.Startup;

public static class AppRepositories
{
    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRepository, Repository>();
    }
}
