using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using test1.Models;

namespace test1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult Index(int age)
        {
            ViewBag.Age = age;
            return View();
        }

        [HttpPost]
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult About(int age)
        {
            ViewBag.Age = age;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
