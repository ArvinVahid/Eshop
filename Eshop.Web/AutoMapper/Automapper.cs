using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Eshop.Core.Entities;
using Eshop.Web.DTOs;

namespace Eshop.Web.AutoMapper
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            #region RegisterDto

            CreateMap<User, RegisterViewModel>();
            CreateMap<RegisterViewModel, User>();

            #endregion

            #region CategoryDto

            CreateMap<Category, CategoryViewModel>()
                .ForMember(dto=>dto.CategoryName,
                    config => config.MapFrom(entity =>
                        entity.Name))

                .ForMember(dto => dto.CategoryDescription,
                    config => config.MapFrom(entity =>
                        entity.Description));

            #endregion

            #region ProductDto

            CreateMap<Product, CategoryProductViewModel>()

                .ForMember(dto => dto.Categories,
                    config => config.MapFrom(entity =>
                        entity.CategoryToProducts.Select(c => c.Category)))

                .ForMember(dto => dto.Price,
                    config => config.MapFrom(entity =>
                        entity.Item.Price));

            #endregion

        }
    }
}
