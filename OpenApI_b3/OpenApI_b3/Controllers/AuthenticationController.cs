using Microsoft.AspNetCore.Mvc;
using OpenApI_b3.Model;

namespace OpenApI_b3.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        [HttpGet("GetServiceToken")]
        public IActionResult GetServiceToken()
        {
            return Ok(ServiceToken.GenerateServiceToken());
        }
    }
}
