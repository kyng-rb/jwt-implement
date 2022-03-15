using jwt_implement.Repositories;
using jwt_implement.Swagger;
using jwt_implement.Auth;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureJWT();

builder.Services.AddScoped<IRepository, Repository>();

var app = builder.Build();

app.ConfigureSwagger();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
