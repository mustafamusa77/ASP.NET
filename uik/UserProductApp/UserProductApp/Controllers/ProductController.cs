using Microsoft.AspNetCore.Mvc;

namespace UserProductApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            // Optional: Add auth check, redirect to login if not logged in
            if (!HttpContext.Session.Keys.Contains("UserId"))
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }
    }
}
