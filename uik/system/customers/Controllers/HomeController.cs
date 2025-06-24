using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using customers.Models;

namespace customers.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(Order order)
    {
        if (ModelState.IsValid)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return RedirectToAction("Success");
        }

        return View(order);
    }

    public IActionResult Success()
    {
        return View();
    }

}
