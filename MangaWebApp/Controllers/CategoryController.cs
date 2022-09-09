using MangaWebApp.Data;
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
            var objCatList = _db.CategoryTable.ToList();
            return View();
        }
    }
}
