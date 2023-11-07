using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Eshop.Core.Entities;

namespace Eshop.Core.Services.Interfaces
{
    public interface ICategoryToProductServices
    {
        Task<List<Product>> GetProductsByGroupId(int id, CancellationToken cancellationToken);
    }
}