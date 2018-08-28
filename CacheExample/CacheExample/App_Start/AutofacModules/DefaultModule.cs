using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using CacheExample.Logic;
using CacheExample.Repositories;

namespace CacheExample.App_Start.AutofacModules
{
    public class DefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductLogic>()
                .AsImplementedInterfaces();

            builder.RegisterType<ProductRepository>()
                .AsImplementedInterfaces();
        }
    }
}