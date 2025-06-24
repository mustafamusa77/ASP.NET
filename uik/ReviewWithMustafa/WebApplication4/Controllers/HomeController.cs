using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index(UserModel userModel)
    {
        if (userModel.Age > 18)
        {
            return RedirectToAction("UserInfo", userModel);
        }
        else
        {
             ModelState.AddModelError("","age over 18 try againt");
        
        }
        
        return View(userModel);
    }
    public IActionResult UserInfo(UserModel userModel)
    {
        return View(userModel);
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
