using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwt_implement.Auth;
using jwt_implement.Models;
using jwt_implement.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jwt_implement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] User credentials)
        {
            var tokenService = new Token();
            var userRepository = new UserRepository();

            var user = userRepository.GetUser(credentials.UserName);

            var token = tokenService.CreateToken(user);

            return Ok(new LoginResponse()
            {
                User = user,
                Token = token
            });
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Authenticated - {0}", User.Identity.Name);

        [HttpGet]
        [Route("admin")]
        [Authorize(Roles = "Admin")]
        public string Tester()
        {
            return "You are a Tester";
        }
    }
}