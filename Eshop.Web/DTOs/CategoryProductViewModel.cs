using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eshop.Core.Entities;

namespace Eshop.Web.DTOs
{
    public class CategoryProductViewModel
    {
        #region Products

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ItemId { get; set; }


        public List<Category> Categories { get; set; }
        public Item Item { get; set; }


        #endregion
    }
}
