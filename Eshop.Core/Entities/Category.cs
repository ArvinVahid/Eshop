using System;
using System.Collections.Generic;
using System.Text;

namespace Eshop.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        #region Relations

        public List<CategoryToProduct> CategoryToProducts { get; set; }

        #endregion
    }
}
