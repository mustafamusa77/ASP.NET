using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index(InputModel model)
        {
            if (model.Number > 10)
            {
                model.Result = "The Number is greater than 10";
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
         [Route("Profile")]
        public IActionResult Profile()
        {
            return View();
        }
         [Route("Setting")]
        public IActionResult Setting()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
