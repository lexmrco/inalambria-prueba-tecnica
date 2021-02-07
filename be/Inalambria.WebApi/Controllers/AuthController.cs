using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Inalambria.WebApi.JWT;
using Inalambria.WebApi.Models;

namespace Inalambria.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            string user = "admin";
            string password = "admin2021";
            if (!ModelState.IsValid)
            {
                return BadRequest("User and Password are required");
            }
            if (!(user == model.UserName && model.Password == password))
                return BadRequest(new { message = "Username or password is incorrect" });
            string token = new TokenGenerator().GetToken(user);
            return Ok(token);
        }

        [HttpGet("[action]")]
        public string EchoUser()
        {
            var identity = User.Identity;
            return $" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}";
        }
    }
}
