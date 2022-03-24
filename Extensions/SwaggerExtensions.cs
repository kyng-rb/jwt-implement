using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace jwt_implement.Extensions;

public static class SwaggerExtensions
{
    public static SwaggerGenOptions BearerSecurity(this SwaggerGenOptions options)
    {
        var securityScheme = new OpenApiSecurityScheme
        {
            Name = "JWT Authentication",
            Description = "Enter JWT Bearer token **_only_**",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            Reference = new OpenApiReference
            {
                Id = JwtBearerDefaults.AuthenticationScheme,
                Type = ReferenceType.SecurityScheme
            }
        };

        options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        securityScheme, new string[] { }
                    }
                });


        return options;
    }

    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.BearerSecurity();
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Jwt Implement Api",
                Description = "A sexy description",
                TermsOfService = new Uri("https://www.youtube.com/watch?v=dQw4w9WgXcQ"),
                Contact = new OpenApiContact()
                {
                    Name = "Fancy developer",
                    Url = new Uri("https://www.youtube.com/watch?v=dQw4w9WgXcQ")
                },
                License = new OpenApiLicense()
                {
                    Name = "No license",
                    Url = new Uri("https://www.youtube.com/watch?v=dQw4w9WgXcQ")
                }
            });
        });
    }

    public static void ConfigureSwagger(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
            return;

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        });
    }
}
