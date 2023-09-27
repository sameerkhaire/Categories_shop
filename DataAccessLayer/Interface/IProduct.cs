using ModelLayer.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IProduct:IRepo<Product>
    {
        void update(Product product);   
        void Remove(Product product);
    }
}
