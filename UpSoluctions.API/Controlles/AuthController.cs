using Microsoft.AspNetCore.Mvc;
using UpSoluctions.Data.Entities;
using UpSoluctions.Services;


namespace UpSoluctions.API.Controlles
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if (username == "filipe" && password == "123456") {
                var token = TokenService.GenerateToken(new Employee());
            }
            

            return BadRequest("username or password invalid");
        }
    }
}
