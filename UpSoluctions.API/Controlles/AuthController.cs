using Microsoft.AspNetCore.Mvc;
using UpSoluctions.Data.Entities;
using UpSoluctions.Services;


namespace UpSoluctions.API.Controlles
{

    [ApiController]
    [Route("api/auth")]
    public class AuthController(TokenService tokenService) : Controller
    {
        private readonly TokenService _tokenService = tokenService;

        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if (username == "filipe" && password == "123456") {
                var token = _tokenService.GenerateToken(new Employee());
                return Ok(token);
            }
            

            return BadRequest("username or password invalid");
        }
    }
}
