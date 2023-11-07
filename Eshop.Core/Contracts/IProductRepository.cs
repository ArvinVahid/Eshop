using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Eshop.Core.Entities;

namespace Eshop.Core.Contracts
{
    public interface IProductRepository : IRepository<Product>
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