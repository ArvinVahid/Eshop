using System;
using System.Collections.Generic;
using System.Text;

namespace Eshop.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ItemId { get; set; }

        #region Relations

        public List<CategoryToProduct> CategoryToProducts { get; set; }
        public Item Item { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        #endregion
    }
}
