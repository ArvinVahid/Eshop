using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Eshop.Core.Entities;
using Eshop.Web.DTOs;

namespace Eshop.Web.AutoMapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, RegisterViewModel>();
        }
    }
}
