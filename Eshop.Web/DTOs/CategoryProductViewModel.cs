using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eshop.Core.Entities;

namespace Eshop.Web.DTOs
{
    public class CategoryProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ItemId { get; set; }
        public int Price { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
    }
}
