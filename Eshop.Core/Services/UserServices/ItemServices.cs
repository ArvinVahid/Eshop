using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eshop.Core.Entities;
using Eshop.Core.Services.Interfaces;
using Eshop.Data.Context;

namespace Eshop.Data.UserServices
{
    public class ItemServices : IItemServices
    {
        private readonly IEshopContext _context;

        public ItemServices(IEshopContext context)
        {
            _context = context;
        }
        public void AddItem(Item item)
        {
            _context.Items.Add(item);
        }
        public void RemoveItem(Item item)
        {
            _context.Items.Remove(item);
        }
        public Item GetItemById(int id)
        {
            return _context.Items.SingleOrDefault(i => i.Id == id);
        }
    }
}
