using Microsoft.AspNetCore.Mvc;

namespace UpSoluctions.API.Controlles
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        [HttpHead]
        public IActionResult Get()
        {
            return NoContent();
        }
    }
}
