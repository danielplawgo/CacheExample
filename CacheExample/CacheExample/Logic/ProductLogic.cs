using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CacheExample.Models;
using CacheExample.Repositories;
using CacheExample.Services;

namespace CacheExample.Logic
{
    public class ProductLogic : IProductLogic
    {
        private Lazy<IProductRepository> _repository;

        protected IProductRepository Repository
        {
            get { return _repository.Value; }
        }

        private Lazy<ICacheService> _cacheService;

        protected ICacheService CacheService
        {
            get { return _cacheService.Value; }
        }

        public ProductLogic(Lazy<IProductRepository> repository,
            Lazy<ICacheService> cacheService)
        {
            _repository = repository;
            _cacheService = cacheService;
        }

        public IEnumerable<Product> GetAll()
        {
            return Repository.GetAll();
        }

        public Product GetById(int id)
        {
            return CacheService.GetOrAdd(CacheKey(id), () => Repository.GetById(id));
        }

        public Product Update(Product product)
        {
            Repository.Update(product);

            CacheService.Remove(CacheKey(product.Id));

            return product;
        }

        public void Delete(Product product)
        {
            Repository.Delete(product);

            CacheService.Remove(CacheKey(product.Id));
        }

        private string CacheKey(int id)
        {
            return $"Product-{id}";
        }
    }
}