using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CheckNumber5.Models;

namespace CheckNumber5.Controllers;

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
    [HttpPost]
    public IActionResult Index(int month)
    {
        string[] months ={
            "January","February","March","April","May","June","July","August","September","October","November","December"
        };
        if (month > 12 || month < 1)
        {
            ViewBag.Message = "The month should be between (1-12)";
        }
        else
        {
            ViewBag.Month ="Month: "+ months[month -1];
            return View();
        }
        return View();
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
