using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OpenApI_b3.Model;
using System.ComponentModel.DataAnnotations;

namespace OpenApI_b3.Controllers
{
    
    [Route("[controller]")]
    public class TestB3Controller : Controller
    {
        
        [HttpGet("GetName"), Authorize]
        [EnableCors("Policy_2")]
        public IActionResult GetName(int k)
        {
            var testObj = new {
                Typep=1,
                Typep_b = "",
                Typep_c = DateTime.Now.Date
            };

            return Ok(testObj);
        }

        [HttpGet]
        [Route("[Action]/{i}")]
        public IActionResult LstEducation(int i)
        {
            List<Education> lstEducation = new List<Education>();

            Education education = new Education();
            education.Name = "A";
            education.Institute = "B";
            education.Degree = "C";
            education.GPA = "D";

            if (i == 1)
                lstEducation.Add(education);

            education = new Education();
            education.Name = "E";
            education.Institute = "f";
            education.Degree = "g";
            education.GPA = "h";

            if (i == 2)
                lstEducation.Add(education);

            return Ok(lstEducation);
        }

        [HttpPost]
        [Route("[Action]")]
        public IActionResult SaveName([FromBody] Education education)
        {
            return Ok("You just save "+ education.Name);
        }

        [HttpPost]
        [Route("[Action]")]
        public IActionResult SaveEdu([FromBody] Education education, int i, [Required] int j)
        {
            return Ok("You just save " + education.Name);
        }

        [HttpPost]
        [Route("[Action]")]
        public IActionResult SaveFile(IFormFile file)
        {
            return Ok(file.FileName);
        }
    }
}
