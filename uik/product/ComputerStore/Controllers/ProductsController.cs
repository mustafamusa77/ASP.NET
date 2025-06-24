using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerStore.Models;

namespace ComputerStore.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    public class ProductsController : Controller
    {
        private List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Gaming Laptop", Description = "High-performance laptop", Price = 1200, ImageUrl = "/images/laptop.jpg" },
            new Product { Id = 2, Name = "Mechanical Keyboard", Description = "RGB backlit keyboard", Price = 150, ImageUrl = "/images/keyboard.jpg" },
            new Product { Id = 3, Name = "Gaming Mouse", Description = "High precision mouse", Price = 50, ImageUrl = "/images/mouse.jpg" }
        };

        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            return View(product);
        }
    }

}