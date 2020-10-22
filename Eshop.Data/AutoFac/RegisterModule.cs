using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using Module = Autofac.Module;

namespace Eshop.Data.AutoFac
{
    public class RegisterModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var dataAccess = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(dataAccess)
                .Where(t => t.Name.EndsWith("Services"))
                .AsImplementedInterfaces();
        }
    }
}
