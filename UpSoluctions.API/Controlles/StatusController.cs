using Microsoft.AspNetCore.Mvc;

namespace UpSoluctions.API.Controlles
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { status = "API is online" });
        }
    }
}
