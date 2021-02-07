using Microsoft.AspNetCore.Mvc;

namespace Inalambria.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "pong";
        }
    }
}
