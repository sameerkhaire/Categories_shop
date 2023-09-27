using DataAccessLayer.Data;
using DataAccessLayer.Implementation;
using Microsoft.EntityFrameworkCore;
using ModelLayer.DB;

namespace MyCategoryProductTest
{
    public class CategoryServiceTest
    {
        private static DbContextOptions<ProductCategoryDbContext> _db = new DbContextOptionsBuilder<ProductCategoryDbContext>().UseInMemoryDatabase(databaseName: "Mvc_Category_product").Options;
        ProductCategoryDbContext db;
        CategoryRepo catRepo;
        [OneTimeSetUp]
        public void Setup()
        {
            db = new ProductCategoryDbContext(_db);
            db.Database.EnsureCreated();
            catRepo = new CategoryRepo(db);
            //seedDataBase();
        }
        [Test,Order(1)]
        public void GetAllCategory()
        {
            var result=catRepo.GetAll();
         Assert.AreEqual(1, result.Count());
        }
        [OneTimeTearDown]
        public void CleanUp()
        {
            db.Database.EnsureDeleted();
        }
        public void seedDataBase()
        {
            var cat = new List<Category>() { new Category() { categoryId = 2, CategoryName = "Lunch Box", DisplayOrder = 2 }, new Category() { categoryId = 3, CategoryName = "Bottle", DisplayOrder = 3 } };
            db.Categories.AddRange(cat);
        }
    }
}