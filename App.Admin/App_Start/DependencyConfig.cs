using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using App.Core;
using System.Web.Mvc;
using Autofac.Integration.Mvc;

namespace App.Admin
{
    public static class DependencyConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            DependencyRegisterType.SystemRegister(ref builder);
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}