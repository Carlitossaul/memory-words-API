using memory_words.Models;
using memory_words.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace memory_words.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("register")]
        public IActionResult Register(Login login)
        {
            var result = _loginService.Register(login);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest("Registration failed");
        }

        [HttpPost("auth")]
        public IActionResult Auth(Login login) 
        {      
            if(!string.IsNullOrEmpty(login.Email) && !string.IsNullOrEmpty(login.Password))
            {
                var result = _loginService.Auth(login.Email, login.Password);
                if(result != null)
                {
                    return Ok(result);
                }
                return BadRequest("Invalid email or password");
            }   
            return BadRequest("Email and password are required");
        }

    }
}
