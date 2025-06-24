using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using crud.Models;
using crud.Data;
using crud.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace crud.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Home/Index
        public async Task<IActionResult> Index()
        {
            var viewModel = new ContactViewModel
            {
                Contact = new Contact(),
                ContactList = await _context.Contacts.ToListAsync()
            };
            return View(viewModel);
        }

        // POST: Home/Index - Create new Contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model.Contact);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Contact created successfully!";
                return RedirectToAction(nameof(Index));
            }

            // If invalid, reload contacts list and return
            model.ContactList = await _context.Contacts.ToListAsync();
            return View(model);
        }

            // GET: Home/ViewContacts
        public async Task<IActionResult> ViewContacts()
        {
            var contacts = await _context.Contacts.ToListAsync();
            return View(contacts);
        }
        // GET: Home/Edit/{id} - Load contact for editing
        public async Task<IActionResult> Edit(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
                return NotFound();

            var viewModel = new ContactViewModel
            {
                Contact = contact,
                ContactList = await _context.Contacts.ToListAsync()
            };
            return View("Index", viewModel);
        }

        // POST: Home/Edit - Update contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Contact updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            // If update failed, reload list
            var viewModel = new ContactViewModel
            {
                Contact = contact,
                ContactList = await _context.Contacts.ToListAsync()
            };
            return View("Index", viewModel);
        }

        // POST: Home/Delete/{id} - Delete contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Contact deleted successfully!";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
