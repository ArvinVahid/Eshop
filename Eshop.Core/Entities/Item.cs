using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace Eshop.Core.Entities
{
    public class Item : BaseEntity<int>
    {
        public int Price { get; set; }
        public int QuantityInStock { get; set; }


        #region Relation
        public Product Product { get; set; }
        #endregion
    }
}
