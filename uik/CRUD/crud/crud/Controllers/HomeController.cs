using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using crud.Models;
using crud.Data;
using Microsoft.EntityFrameworkCore;

namespace crud.Controllers;

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

    // POST: Contact/Create
    [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Contact created successfully!";
                return RedirectToAction(nameof(Index));
            }

            return View(contact);
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
