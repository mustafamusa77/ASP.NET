using  System.Diagnostics;
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

    // 
    // [HttpPost]
    // public IActionResult Insert(Contact contact)
    // {
    //     _context.news.Add(contact);
    //     _context.SaveChanges();
    //     return RedirectToAction("Index");
    // }
    // [HttpPost]
    // public IActionResult Update(Contact contact)
    // {
    //     _context.news.Update(contact);
    //     _context.SaveChanges();
    //     return RedirectToAction("Index");
    // }
    // [HttpPost]
    // public IActionResult Delete(int id)
    // {
    //     var contact = _context.news.Find(id);
    //     if (contact != null)
    //     {
    //         _context.news.Remove(contact);
    //         _context.SaveChanges();
    //     }
    //     return RedirectToAction("Index");
    // }


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

        public async Task<IActionResult> Privacy()
        {
            var contents= await _context.news.ToListAsync();
            return View(contents);
        }

        public ActionResult Index()
        {
            var contacts = _context.news.ToList();
            return View(contacts);
        }

        [HttpPost]
        public ActionResult Insert(Contact contact)
        {
            _context.news.Add(contact);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var contact = _context.news.Find(id);
            return View("Form", contact);
        }

        [HttpPost]
        public ActionResult Update(Contact contact )
        {
            _context.Entry(contact).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var contact = _context.news.Find(id);
            _context.news.Remove(contact);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult New()
        {
            return View("Form", new Contact());
        }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

