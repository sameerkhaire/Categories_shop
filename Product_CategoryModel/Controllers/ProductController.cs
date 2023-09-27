using DataAccessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModelLayer.DB;

namespace Product_CategoryModel.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _product;
        private readonly Icategory _category;
        public ProductController(IProduct product, Icategory category)
        {
            _product = product;
            _category = category;

        }
        public IActionResult Index()
        {
           var data= _product.GetAll().ToList();
            //ViewBag.Data = new SelectList(datalist, "categoryId", "CategoryName");
            
            return View(data);
        }
        [HttpGet] 
        public IActionResult AddProd()
        {
            IEnumerable<SelectListItem> datalist = _category.GetAll().ToList().Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.categoryId.ToString()
            });
            ViewBag.datalistt=datalist;
            return View();
        }
        [HttpPost]
        public IActionResult AddProd(Product product)
        {
            if (product != null)
            {
                _product.Add(product);
                _product.save();
                return RedirectToAction("Index");
            }
            return PartialView("Error");
        }
        [HttpGet]
        public IActionResult EditProd(int id)
        {
            var data = _product.Get(x => x.productId == id);
            return View(data);
        }
        [HttpPost]
        public IActionResult EditProd(Product product)
        {
            if(product.productId == 0) { return PartialView("Error"); }
            _product.update(product);
            _product.save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteProd(Product product)
        {
            if (product.productId == 0) { return PartialView("Error"); }
            _product.Remove(product);
            _product.save();
            return RedirectToAction("Index");
        }
    }
}
