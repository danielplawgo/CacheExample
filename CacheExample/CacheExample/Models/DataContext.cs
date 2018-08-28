using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CacheExample.Models
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("Name=DefaultConnection")
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}