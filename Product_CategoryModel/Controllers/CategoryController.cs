using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DB;

namespace Product_CategoryModel.Controllers
{
    public class CategoryController : Controller
    {
        private readonly Icategory _context;
        public CategoryController(Icategory context) 
        { 
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var data = _context.GetAll().ToList();
            return View(data);
        }
        [HttpGet]   
        public IActionResult AddCat()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCat(Category category)
        {
            if(category == null)
            {
                return PartialView("Error");
            }
            _context.Add(category);
            _context.save();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditCat(int id)
        {
            var data = _context.Get(x => x.categoryId == id);
            return View(data);
        }
        [HttpPost]
        public IActionResult EditCat(Category category)
        {
            if(category == null) { return PartialView("Error"); }
            _context.Update(category);
            _context.save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteCat(Category category)
        {
            if (category.categoryId == 0) {return PartialView("Error"); } 
            var data = _context.Get(x => x.categoryId == category.categoryId);
            _context.Remove(data);
            _context.save();
            return RedirectToAction("Index");
        }

    }
}
