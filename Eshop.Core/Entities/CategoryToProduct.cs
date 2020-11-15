using System;
using System.Collections.Generic;
using System.Text;

namespace Eshop.Core.Entities
{
    public class CategoryToProduct
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        #region Relations

        public Category Category { get; set; }
        public Product Product { get; set; }
        public Item Item { get; set; }

        #endregion
    }
}
