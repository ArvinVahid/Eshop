using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Eshop.Core.Contracts;
using Eshop.Core.Entities;
using Eshop.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(EshopContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Product> GetAllProducts()
        {
            return TableNoTracking.Include(p => p.Item);
        }

        public async Task AddProduct(Product product, CancellationToken cancellationToken)
        {
            await AddAsync(product, cancellationToken);
        }

        public async Task RemoveProduct(Product product, CancellationToken cancellationToken)
        {
            await DeleteAsync(product, cancellationToken);
        }

        public async Task<Product> GetProductById(int id, CancellationToken cancellationToken)
        {
            var product = await GetByIdAsync(cancellationToken, id);
            return product;
        }

        public async Task<Product> GetProductByIdIncludeItem(int id, CancellationToken cancellationToken)
        {
            return await Entities.Include(p => p.Item)
                .SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<Product> GetProductByIdIncludeCategoryProducts(int id, CancellationToken cancellationToken)
        {
            return await Entities.Include(p => p.CategoryToProducts)
                .SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<Product> GetAdminProductById(int id, CancellationToken cancellationToken)
        {
            return await Entities.Include(i => i.Item)
                .SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
        }
    }
}