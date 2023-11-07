using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Eshop.Core.Contracts;
using Eshop.Core.Entities;
using Eshop.Core.Services.Interfaces;
using Eshop.Data.Context;

namespace Eshop.Core.Services.UserServices
{
    public class ItemServices : IItemServices
    {
        private readonly IItemRepository _itemRepository;
        public ItemServices(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        
        public async Task AddItem(Item item, CancellationToken cancellationToken)
        {
            await _itemRepository.AddItem(item, cancellationToken);
        }
        public async Task RemoveItem(Item item, CancellationToken cancellationToken)
        { 
            await _itemRepository.RemoveItem(item, cancellationToken);
        }
        public async Task<Item> GetItemById(int id, CancellationToken cancellationToken)
        {
            return await _itemRepository.GetItemById(id, cancellationToken);
        }
    }
}
