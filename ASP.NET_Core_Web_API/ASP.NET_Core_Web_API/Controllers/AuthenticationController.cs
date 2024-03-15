using ASP.NET_Core_Web_API.Models;
using ASP.NET_Core_Web_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        public AuthenticationController(IJwtService jwtService)
        {
            this._jwtService = jwtService;
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login(UserCredentialsModel userCredentials)
        {
            var token = _jwtService.Authentication(userCredentials.username, userCredentials.password);
            return Ok(token);
        }
    }
}