using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementation
{
    public class Repo<T> : IRepo<T> where T : class
    {
        private readonly ProductCategoryDbContext _context;
        public Repo(ProductCategoryDbContext context)
        {
            _context = context;   
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
           return  _context.Set<T>().Where(filter).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public void save()
        {
            _context.SaveChanges();
        }
        //public void Remove(T entity)
        //{
        //    _context.Set<T>().Remove(entity);
        //}

        //public void Update(T entity)
        //{
        //    _context.Set<T>().Update(entity);
        //}
    }
}
