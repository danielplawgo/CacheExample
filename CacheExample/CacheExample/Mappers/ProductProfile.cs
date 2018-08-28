using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using CacheExample.Models;
using CacheExample.ViewModels.Products;

namespace CacheExample.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ReverseMap();
        }
    }
}