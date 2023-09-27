using DataAccessLayer.Data;
using DataAccessLayer.Implementation;
using DataAccessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelLayer.DB;
using Moq;
using Product_CategoryModel.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCategoryProductTest
{
    public class CategoryControllerTest
    {
        private static DbContextOptions<ProductCategoryDbContext> _db = new DbContextOptionsBuilder<ProductCategoryDbContext>()
               .UseInMemoryDatabase(databaseName: "Mvc_Category_product").Options;
        ProductCategoryDbContext context;
        CategoryRepo catRepo;
        CategoryController catController;
        [OneTimeSetUp]
        public void Setup()
        {
           
            context = new ProductCategoryDbContext(_db);
            context.Database.EnsureCreated();
            seedDataBase();
            catRepo = new CategoryRepo(context);
            catController = new CategoryController(catRepo);

            
        }

        private void seedDataBase()
        {
            var cat = new List<Category>()
            {
                new Category
                {
                    categoryId = 1,
                    CategoryName="food",
                    DisplayOrder=2
                }
            };
            context.AddRange(cat);
            context.SaveChanges();
        }

        [Test,Order(1)]
        public void HTTPGET_GetallCategory_Test()
        {
          

            IActionResult actionResult = catController.Index();

           

            Assert.That(actionResult,Is.TypeOf<ViewResult>());
            var actResult = actionResult as ViewResult;
            var test = (actResult.Model as List<Category>).ToList();
            Assert.That(test.FirstOrDefault().CategoryName, Is.EqualTo("food"));
            //Assert.That(actResult.Count(), Is.EqualTo(1));
        }
        [Test,Order(2)]
        public void HTTPPOST_AddCat_Test()
        {
            var data = new Category { CategoryName = "Electronics", DisplayOrder = 1 };
            IActionResult actionResult= catController.AddCat(data);
            Assert.That(actionResult,Is.TypeOf<RedirectToActionResult>());
         
        }
        [Test, Order(3)]
        public void HTTPPUT_EditCat_Test()
        {
            var data = new Category { CategoryName = "Electronics", DisplayOrder = 1 };
            IActionResult actionResult = catController.EditCat(data);
            Assert.That(actionResult, Is.TypeOf<RedirectToActionResult>());

        }
        [Test, Order(4)]
        public void HTTPDELETE_DeleteCat_Test()
        {
            var data = new Category { categoryId = 1 };
            IActionResult actionResult = catController.DeleteCat(data);
            Assert.That(actionResult, Is.TypeOf<RedirectToActionResult>());
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }
    }
}
