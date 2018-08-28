using Bogus;
using CacheExample.Models;

namespace CacheExample.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CacheExample.Models.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CacheExample.Models.DataContext context)
        {
            if (context.Products.Any() == false)
            {
                var products = new Faker<Product>()
                    .RuleFor(u => u.Name, (f, u) => f.Commerce.ProductName())
                    .Generate(1000);

                foreach (var product in products)
                {
                    context.Products.AddOrUpdate(u => u.Name, product);
                }
            }
        }
    }
}
