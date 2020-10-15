using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Eshop.Core.Services.Interfaces;
using Eshop.Data.UserServices;

namespace Eshop.Web.ServicesModule
{
    public class ServicesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<ProductServices>().As<IProductServices>();
            builder.RegisterType<ItemServices>().As<IItemServices>();
            builder.RegisterType<OrderServices>().As<IOrderServices>();
            builder.RegisterType<UserServices>().As<IUserServices>();
        }
    }
}
