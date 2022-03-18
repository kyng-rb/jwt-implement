using System.Text;
using jwt_implement.Models.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace jwt_implement.Extensions;

public static class AuthExtensions
{
    public static void ConfigureJWT(this IServiceCollection services, IConfiguration config)
    {
        var securityOptions = config.GetSection(SecurityOptions.FieldName).Get<SecurityOptions>();
        var key = Encoding.ASCII.GetBytes(securityOptions.Key);

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidIssuer = securityOptions.Issuer,
                ValidAudience = securityOptions.Audience
            };
        });

    }
}
