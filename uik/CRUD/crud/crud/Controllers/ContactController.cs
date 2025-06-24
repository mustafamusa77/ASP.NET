using Microsoft.AspNetCore.Mvc;
using crud.Models;
using crud.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace crud.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Contact
        public async Task<IActionResult> Index()
        {
            var contacts = await _context.Contacts.ToListAsync();
            return View(contacts);
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
    }
}
