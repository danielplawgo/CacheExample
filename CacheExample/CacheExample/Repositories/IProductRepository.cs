using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CacheExample.Models;

namespace CacheExample.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();

        Product GetById(int id);

        void Update(Product product);

        void Delete(Product product);
    }
}
