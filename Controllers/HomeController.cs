using jwt_implement.Auth;
using jwt_implement.Models;
using jwt_implement.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jwt_implement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    private readonly IRepository _repository;
    public HomeController(IRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public IActionResult Login([FromBody] User credentials)
    {
        var tokenService = new Token();
        var user = _repository.GetBy(credentials.Email);
        var token = tokenService.CreateToken(user);
        return Ok(new LoginResponse()
        {
            User = user,
            Token = token
        });
    }

    [HttpGet]
    [Route("Authenticated")]
    [Authorize]
    public IActionResult Authenticated() => Ok($"Authenticated - { User.Identity.Name }");

    [HttpGet]
    [Route("Admin")]
    [Authorize(Roles = "Admin")]
    public IActionResult Admin() => Ok("You are an Admin");
}
