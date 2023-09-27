using DataAccessLayer.Implementation;
using ModelLayer.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface Icategory:IRepo<Category>
    {
        void Update(Category entity);
        void Remove(Category entity);
    }
}
