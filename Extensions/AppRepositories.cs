using jwt_implement.Auth;
using jwt_implement.Repositories;

namespace jwt_implement.Extensions;

public static class AppRepositories
{
    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRepository, Repository>();
        services.AddScoped<ICreateToken, CreateToken>();
    }
}
