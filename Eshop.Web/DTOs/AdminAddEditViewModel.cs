using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Eshop.Web.DTOs
{
    public class AdminAddEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int QuantityInStock { get; set; }
        public IFormFile Picture { get; set; }
    }
}
