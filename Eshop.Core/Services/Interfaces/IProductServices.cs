using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Eshop.Core.Entities;

namespace Eshop.Core.Services.Interfaces
{
    public interface IProductServices
    {
        IQueryable<Product> GetAllProducts();
        Task AddProduct(Product product, CancellationToken cancellationToken);
        Task RemoveProduct(Product product, CancellationToken cancellationToken);
        Task<Product> GetProductById(int id, CancellationToken cancellationToken);
        Task<Product> GetProductByIdIncludeItem(int id, CancellationToken cancellationToken);
        Task<Product> GetProductByIdIncludeCategoryProducts(int id, CancellationToken cancellationToken);
        Task<Product> GetAdminProductById(int id, CancellationToken cancellationToken);

    }
}
