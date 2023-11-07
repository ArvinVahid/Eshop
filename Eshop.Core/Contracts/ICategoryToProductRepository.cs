using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Eshop.Core.Entities;

namespace Eshop.Core.Contracts
{
    public interface ICategoryToProductRepository : IRepository<CategoryToProduct>
    {
        Task<List<Product>> GetProductsByGroupId(int id, CancellationToken cancellationToken);
    }
}