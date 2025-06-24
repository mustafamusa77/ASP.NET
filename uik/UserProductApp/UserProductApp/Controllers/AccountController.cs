using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserProductApp.Data;
using UserProductApp.Models;

namespace UserProductApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Account/SignUp
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        // POST: /Account/SignUp
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                bool emailExists = await _context.Users.AnyAsync(u => u.Email == user.Email);
                if (emailExists)
                {
                    ModelState.AddModelError("Email", "Email already registered.");
                    return View(user);
                }

                // In production, you must hash passwords before saving!
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Account created successfully! Please login.";
                return RedirectToAction("Login");
            }
            return View(user);
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Please provide email and password.";
                return View();
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            if (user == null)
            {
                ViewBag.Error = "Invalid email or password.";
                return View();
            }

            // Set session to keep user logged in
            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("UserName", user.Name ?? "");

            return RedirectToAction("Index", "Product");
        }

        // GET: /Account/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
