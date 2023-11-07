using System.Threading;
using System.Threading.Tasks;
using Eshop.Core.Entities;

namespace Eshop.Core.Contracts
{
    public interface IItemRepository : IRepository<Item>
    {
        Task AddItem(Item item, CancellationToken cancellationToken);
        Task RemoveItem(Item item, CancellationToken cancellationToken);
        Task<Item> GetItemById(int id, CancellationToken cancellationToken);
    }
}