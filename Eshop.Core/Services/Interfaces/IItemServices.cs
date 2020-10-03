using System;
using System.Collections.Generic;
using System.Text;
using Eshop.Core.Entities;

namespace Eshop.Core.Services.Interfaces
{
    public interface IItemServices
    {
        void AddItem(Item item);
        void RemoveItem(Item item);
        Item GetItemById(int id);

    }
}
