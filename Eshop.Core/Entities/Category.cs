using System;
using System.Collections.Generic;
using System.Text;

namespace Eshop.Core.Entities
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        #region Relations

        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }

        #endregion
    }
}
