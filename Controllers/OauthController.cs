using jwt_implement.Extensions;
using jwt_implement.Services.Oauth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jwt_implement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OauthController : ControllerBase
{
    private readonly ILogin _loginService;

    public OauthController(ILogin loginService)
    {
        _loginService = loginService;
    }

    [HttpPost, Route("Login")]
    [AllowAnonymous]
    public IActionResult Login([FromBody] LoginInput credentials) => _loginService.Login(credentials).ToActionResult();

    [HttpGet, Route("Authenticate")]
    [Authorize]
    public IActionResult Authenticated() => Ok($"Authenticated - {User?.Identity?.Name}");

    [HttpGet, Route("Admins")]
    [Authorize(Roles = "Admin")]
    public IActionResult Admin() => Ok("You are an Admin");
}
