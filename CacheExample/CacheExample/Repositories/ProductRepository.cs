using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CacheExample.Models;

namespace CacheExample.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private Lazy<DataContext> _db;

        protected DataContext Db
        {
            get { return _db.Value; }
        }

        public ProductRepository(Lazy<DataContext> db)
        {
            _db = db;
        }

        public IEnumerable<Product> GetAll()
        {
            return Db.Products;
        }

        public Product GetById(int id)
        {
            return Db.Products.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Product product)
        {
            Db.Products.Attach(product);
            Db.Entry(product).State = EntityState.Modified;

            Db.SaveChanges();
        }

        public void Delete(Product product)
        {
            Db.Products.Attach(product);
            Db.Products.Remove(product);

            Db.SaveChanges();
        }
    }
}