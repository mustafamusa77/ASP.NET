using Microsoft.AspNetCore.Mvc;
using MVC2.Models;

namespace MVC2.Controllers
{
    public class HomeController : Controller
    {
    
        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(int age)
        {
            if (age >= 18 && age <= 30)
                return RedirectToAction("Height", new { age });
            return Content("Access Denied: Age must be between 18 and 30.");
        }

        public IActionResult Height(int age)
        {
            return View(new UserData { Age = age });
        }

        [HttpPost]
        public IActionResult Height(UserData data)
        {
            if (data.Height >= 170)
                return RedirectToAction("Weight", data);
            return Content("Access Denied: Height must be >= 170.");
        }

        public IActionResult Weight(UserData data)
        {
            return View(data);
        }

        [HttpPost]
        public IActionResult SubmitWeight(UserData data)
        {
            if (data.Weight >= 50 && data.Weight <= 70)
                return RedirectToAction("Marks", data);
            return Content("Access Denied: Weight must be between 50 and 70.");
        }

        public IActionResult Marks(UserData data)
        {
            return View(data);
        }

        [HttpPost]
        public IActionResult SubmitMarks(UserData data)
        {
            if (data.Marks >= 70 && data.Marks <= 100)
                return RedirectToAction("Message", data);
            return Content("Access Denied: Marks must be between 70 and 100.");
        }

        public IActionResult Message(UserData data)
        {
            return View(data);
        }
    }
}