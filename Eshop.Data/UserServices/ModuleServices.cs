using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Eshop.Core.Services.Interfaces;

namespace Eshop.Data.UserServices
{
    public class ModuleServices : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<UserServices>().As<IUserServices>().InstancePerLifetimeScope();
            builder.RegisterType<ItemServices>().As<IItemServices>().InstancePerLifetimeScope();
            builder.RegisterType<OrderServices>().As<IOrderServices>().InstancePerLifetimeScope();
            builder.RegisterType<ProductServices>().As<IProductServices>().InstancePerLifetimeScope();
        }
    }
}
