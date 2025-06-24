using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC3.Models;

namespace MVC3.Controllers;

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
    public IActionResult Index(int a=20)
    {
        for (int i=0; i <= a; i++)
        {
            i += i;
        }
        ViewBag.Age = a;
        return View();
    }
    [HttpPost]
    public IActionResult About(int a)
    {
        ViewBag.Age = a;
        return View();
    }

    public IActionResult Privacy(int i=0)
    {
        while (i>=50) {
            i -= 2;
        }
        
            return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
