using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customers.Controllers
{
 public class AdminController : Controller
{
    private readonly AppDbContext _context;

    public AdminController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        if (username == "admin" && password == "1234")
        {
            TempData["IsAdmin"] = true;
            return RedirectToAction("Orders");
        }

        ViewBag.Error = "Invalid credentials";
        return View();
    }

    public IActionResult Orders()
    {
        if (TempData["IsAdmin"] == null) return RedirectToAction("Login");
        return View(_context.Orders.ToList());
    }

    public IActionResult Delete(int id)
    {
        var order = _context.Orders.Find(id);
        if (order != null)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        return RedirectToAction("Orders");
    }
}
    
}