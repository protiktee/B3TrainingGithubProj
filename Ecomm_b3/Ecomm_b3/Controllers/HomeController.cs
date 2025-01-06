using System.Diagnostics;
using Ecomm_b3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecomm_b3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Single()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }


    public class Product
    { 
        public int id { get; set; }
        public string title { get; set; }
        public Dimension dimension { get; set; }
        public List<Reviews> reviews { get; set; }

        public Product()
        {
            dimension = new Dimension();
            reviews = new List<Reviews>();
        }
    }
    public class Dimension 
    {
        public int width { get; set; }
    }
    public class Reviews
    {
        public int rating { get; set; }
    }
}
