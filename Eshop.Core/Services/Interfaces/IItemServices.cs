using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Eshop.Core.Entities;

namespace Eshop.Core.Services.Interfaces
{
    public interface IItemServices
    {
        Task AddItem(Item item, CancellationToken cancellationToken);
        Task RemoveItem(Item item, CancellationToken cancellationToken);
        Task<Item> GetItemById(int id, CancellationToken cancellationToken);

    }
}
