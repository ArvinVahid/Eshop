using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Eshop.Core.Entities;

namespace Eshop.Core.Contracts
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public Task<List<Category>> GetAllCategories(CancellationToken cancellationToken);
    }
}