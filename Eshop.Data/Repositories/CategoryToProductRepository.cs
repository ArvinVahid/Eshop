using Eshop.Core.Contracts;
using Eshop.Core.Entities;
using Eshop.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Data.Repositories
{
    public class CategoryToProductRepository : BaseRepository<CategoryToProduct>, ICategoryToProductRepository
    {
        public CategoryToProductRepository(EshopContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Product>> GetProductsByGroupId(int id, CancellationToken cancellationToken)
        {
            return await TableNoTracking
                .Where(c => c.CategoryId == id)
                .Include(p => p.Product)
                .Select(p => p.Product).ToListAsync(cancellationToken);
        }
    }
}