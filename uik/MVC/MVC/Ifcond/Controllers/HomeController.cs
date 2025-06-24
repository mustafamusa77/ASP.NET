using Microsoft.AspNetCore.Mvc;
using YourApp.Models;

namespace YourApp.Controllers
{
    public class HomeController : Controller
    {
        private static UserModel user = new UserModel();

        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(int age)
        {
            if (age >= 18 && age <= 30)
            {
                user.Age = age;
                return RedirectToAction("Height");
            }
            ViewBag.Message = "Invalid Age Please Enter age between 18 and 30 ";
            return View();
        }

        public IActionResult Height() => View();

        [HttpPost]
        public IActionResult Height(int height)
        {
            if (height >= 170)
            {
                user.Height = height;
                return RedirectToAction("Weight");
            }
            ViewBag.Message = "Invalid Height Please Enter Height more than or equal 170";
            return View();
        }

        public IActionResult Weight() => View();

        [HttpPost]
        public IActionResult Weight(int weight)
        {
            if (weight >= 50 && weight <= 70)
            {
                user.Weight = weight;
                return RedirectToAction("Marks");
            }
            ViewBag.Message = "Invalid Weight Please Enter weight between (50-70)";
            return View();
        }

        public IActionResult Marks() => View();

        [HttpPost]
        public IActionResult Marks(int marks)
        {
            if (marks >= 70 && marks <= 100)
            {
                user.Marks = marks;
                return RedirectToAction("Message");
            }
            ViewBag.Message = "Invalid Marks Please Enter marks between (70-100)";
            return View();
        }

        public IActionResult Message()
        {
            return View(model: "You are allowed!");
      }
    }
}
