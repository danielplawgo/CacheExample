using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CacheExample.Models
{
    [Serializable]
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}