using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using CacheExample.Services;

namespace CacheExample.App_Start.AutofacModules
{
    public class CacheServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CacheService>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}