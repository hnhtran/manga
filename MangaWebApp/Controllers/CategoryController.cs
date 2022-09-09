using MangaWebApp.Data;
using MangaWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MangaWebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;
        public CategoryController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCatList = _db.CategoryTable;
            return View(objCatList);
        }
        // GET
        public IActionResult Create()
        {
            return View();
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            _db.CategoryTable.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
