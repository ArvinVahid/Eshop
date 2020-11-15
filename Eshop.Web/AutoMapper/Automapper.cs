using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Eshop.Core.Entities;
using Eshop.Data.Migrations;
using Eshop.Web.DTOs;

namespace Eshop.Web.AutoMapper
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<User, RegisterViewModel>();
            CreateMap<RegisterViewModel, User>();

            CreateMap<Product, CategoryProductViewModel>()

                .ForMember(dto => dto.CategoryName,
                    config => config.MapFrom(entity =>
                        entity.CategoryToProducts.Select(c => c.Category.Name)))

                .ForMember(dto => dto.CategoryDescription,
                    config => config.MapFrom(entity =>
                        entity.CategoryToProducts.Select(c => c.Category.Description)))


                .ForMember(dto => dto.Price,
                    config => config.MapFrom(entity =>
                        entity.Item.Price));

        }
    }
}
