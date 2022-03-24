using jwt_implement.Extensions;
using jwt_implement.Models.Api;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(x =>
{
    x.Filters.Add(new ProducesResponseTypeAttribute(typeof(ApiResponse), StatusCodes.Status500InternalServerError));
    x.Filters.Add(new ProducesResponseTypeAttribute(typeof(ApiResponse), StatusCodes.Status400BadRequest));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.AddConfigurations(builder.Configuration);
builder.Services.ConfigureRepositories();

var app = builder.Build();

app.ConfigureSwagger();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
