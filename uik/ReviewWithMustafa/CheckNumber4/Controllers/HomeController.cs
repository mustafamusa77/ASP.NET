using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CheckNumber4.Models;

namespace CheckNumber4.Controllers;

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

    public IActionResult Privacy()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index(string Name, int Age)
    {
        if (Age >= 18)
        {
            ViewBag.Name = Name;
            ViewBag.Age = Age;
            return View();
        }
        else
        {
            ViewBag.Message = "Please provide an old Age";
            return RedirectToAction("Index");
        }
        
        
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
