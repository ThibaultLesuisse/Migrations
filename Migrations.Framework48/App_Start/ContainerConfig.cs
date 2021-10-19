using Autofac;
using Migrations.Framework48.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Migrations.Framework48.App_Start
{
    public static class ContainerConfig
    {
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ProductRepository>()
                   .As<IProductRepository>()
                   .InstancePerRequest();
        }
    }
}