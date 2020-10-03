using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eshop.Core.Entities;

namespace Eshop.Web.DTOs
{
    public class CategoryProductViewModel
    {
        public CategoryProductViewModel()
        {
            Categories = new List<Category>();
        }
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}
