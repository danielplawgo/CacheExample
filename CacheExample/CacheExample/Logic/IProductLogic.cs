using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CacheExample.Models;

namespace CacheExample.Logic
{
    public interface IProductLogic
    {
        IEnumerable<Product> GetAll();

        Product GetById(int id);

        Product Update(Product product);

        void Delete(Product product);
    }
}
