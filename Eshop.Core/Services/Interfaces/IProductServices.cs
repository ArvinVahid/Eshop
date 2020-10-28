using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eshop.Core.Entities;

namespace Eshop.Core.Services.Interfaces
{
    public interface IProductServices
    {
        IQueryable<Product> GetAllProducts();
        void AddProduct(Product product);
        void RemoveProduct(Product product);
        List<Product> GetProductsByGroupId(int id);
        List<Category> GetAllCategories();
        Product GetProductById(int id);
        IQueryable<Product> GetProductByIdForDTO(int id);
        Product GetAdminProductById(int id);

    }
}
