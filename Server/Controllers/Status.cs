using Microsoft.AspNetCore.Mvc;

namespace ASPCoreServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Status : Controller
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetStatus()
        {
            return Ok("Server is running");
        }
    }
}
