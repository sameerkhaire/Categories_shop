using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using ModelLayer.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementation
{
    public class CategoryRepo : Repo<Category>, Icategory
    {
        private readonly ProductCategoryDbContext _context;
        public CategoryRepo(ProductCategoryDbContext context) : base(context)
        {
            _context = context;
        }

        public void Remove(Category entity)
        {
            _context.Set<Category>().Remove(entity);
        }

        public void Update(Category entity)
        {
            _context.Set<Category>().Update(entity);
        }
    }
}
