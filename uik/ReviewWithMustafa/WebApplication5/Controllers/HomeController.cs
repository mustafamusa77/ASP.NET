using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // POST: Month
        [HttpPost]
        public ActionResult Index(int monthNumber)
        {
            var model = new MonthModel { MonthNumber = monthNumber };

            if (monthNumber >= 1 && monthNumber <= 12)
            {
                model.MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthNumber);
            }
            else
            {
                model.ErrorMessage = "Please enter a number between 1 and 12.";
            }

            return View(model);
        }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
