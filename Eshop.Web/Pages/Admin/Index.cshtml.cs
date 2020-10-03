using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eshop.Core.Entities;
using Eshop.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop.Web.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly IUserServices _userServices;
        private readonly IItemServices _itemServices;
        private readonly IProductServices _productServices;

        public IndexModel(IUserServices userServices, IItemServices itemServices, IProductServices productServices)
        {
            _userServices = userServices;
            _itemServices = itemServices;
            _productServices = productServices;
        }

        public IEnumerable<Product> Products { get; set; }
        public void OnGet()
        {
            Products = _productServices.GetAllProducts();
        }

        public void OnPost()
        {

        }
    }
}
