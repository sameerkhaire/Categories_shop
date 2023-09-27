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
    public class ProductRepo : Repo<Product>, IProduct
    {
        private readonly ProductCategoryDbContext _context;
        public ProductRepo(ProductCategoryDbContext context) : base(context)
        {
            _context = context;
        }

        public void Remove(Product product)
        {
            _context.Set<Product>().Remove(product);
        }

        public void update(Product product)
        {
            _context.Set<Product>().Update(product);
        }
    }
}
