using jwt_implement.Auth;
using jwt_implement.Repositories;
using jwt_implement.Services.Oauth;

namespace jwt_implement.Extensions;

public static class AppRepositories
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IRepository, Repository>();
        services.AddScoped<ICreateToken, CreateToken>();
        services.AddScoped<ILogin, Login>();
    }
}
