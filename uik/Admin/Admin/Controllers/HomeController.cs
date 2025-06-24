using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Admin.Models;
using Admin.Data;
using Microsoft.EntityFrameworkCore;

namespace Admin.Controllers;

public class HomeController : Controller
{
    private readonly MyDbContext _context;

    public HomeController(MyDbContext context)
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