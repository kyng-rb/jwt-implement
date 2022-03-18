using jwt_implement.Models.Configuration;

namespace jwt_implement.Extensions;

public static class ServiceConfigureExtensions
{
    public static void AddConfigurations(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<SecurityOptions>(config.GetSection(SecurityOptions.FieldName));
    }
}
