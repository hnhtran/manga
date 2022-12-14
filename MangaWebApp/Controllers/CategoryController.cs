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
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Display Order and Name cannot be same");
            }
            if (ModelState.IsValid)
            {
                _db.CategoryTable.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Successfully create category";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var catFromDb = _db.CategoryTable.Find(id);
            //var catFromDbFirst = _db.CategoryTable.FirstOrDefault(c => c.Id == id);
            //var catFromDbWhere = _db.CategoryTable.SingleOrDefault(c => c.Id == id);

            if (catFromDb == null)
            {
                return NotFound();
            }
            return View(catFromDb);
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Display Order and Name cannot be same");
            }
            if (ModelState.IsValid)
            {
                _db.CategoryTable.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Successfully edit category";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var catFromDb = _db.CategoryTable.Find(id);
            //var catFromDbFirst = _db.CategoryTable.FirstOrDefault(c => c.Id == id);
            //var catFromDbWhere = _db.CategoryTable.SingleOrDefault(c => c.Id == id);

            if (catFromDb == null)
            {
                return NotFound();
            }
            return View(catFromDb);
        }
        // POST
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.CategoryTable.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
                _db.CategoryTable.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Successfully delete category";
            return RedirectToAction("Index");
        }

    }
}
