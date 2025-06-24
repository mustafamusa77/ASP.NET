using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoopsCondition1.Models;

namespace LoopsCondition1.Controllers;

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
    public IActionResult Index(int number)
    {
        ViewBag.Number = number;
        return View();
    }

    public IActionResult Privacy()
    {
        ViewBag.Counter = 1;
        return View();
    }
    [HttpPost]
    public IActionResult Privacy(int counter)
    {
        if (counter == 10)
        {
            ViewBag.Counter = counter;
            ViewBag.Message = "You reached the limitation";
            return View();
        }
        else
        {
             ViewBag.Counter = counter + 1;
             return View();
        }
    }
    public IActionResult Calcalate()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Calcalate(int number)
    {
        ViewBag.Number = number;
        return View();
    }
     public IActionResult About()
    {
        ViewBag.Counter = 0;
        return View();
    }
    [HttpPost]
    public IActionResult About(int counter)
    {
        if (counter == 100)
        {
            ViewBag.Counter = counter;
            ViewBag.Message = "You reached the limitation";
            return View();
        }
        else
        {
             ViewBag.Counter = counter + 10;
             return View();
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
