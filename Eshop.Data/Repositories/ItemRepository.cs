using System.Threading;
using System.Threading.Tasks;
using Eshop.Core.Contracts;
using Eshop.Core.Entities;
using Eshop.Data.Context;

namespace Eshop.Data.Repositories
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(EshopContext dbContext) : base(dbContext)
        {
        }

        public async Task AddItem(Item item, CancellationToken cancellationToken)
        {
            await AddAsync(item, cancellationToken);
        }

        public async Task RemoveItem(Item item, CancellationToken cancellationToken)
        {
            await DeleteAsync(item, cancellationToken);
        }

        public async Task<Item> GetItemById(int id, CancellationToken cancellationToken)
        {
            return await GetByIdAsync(cancellationToken, id);
        }
    }
}