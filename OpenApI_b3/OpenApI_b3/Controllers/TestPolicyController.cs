using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace OpenApI_b3.Controllers
{
    [Route("api/[controller]")]
    public class TestPolicyController : Controller
    {
        
        [HttpGet(Name = "Index"), Authorize]
        public ActionResult Index()
        {
            return Ok(new { ff = "this is private access" });
        }
        [EnableCors("Policy_1")]
        [HttpGet("QryFromUnauthArea")]
        public ActionResult QryFromUnauthArea()
        {
            return Ok(new { token = "this is public access" });
        }
        [EnableCors("Policy_2")]
        [HttpGet("QryFromUnauthArea_2")]
        public ActionResult QryFromUnauthArea_2()
        {

            return Ok(new { token = "this is public access:QryFromUnauthArea_2" });
        }
    }
}
