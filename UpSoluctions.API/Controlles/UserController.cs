using Microsoft.AspNetCore.Mvc;
using UpSoluctions.Data.Dtos;

namespace UpSoluctions.API.Controlles
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateUser(CreateUserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
