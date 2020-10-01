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
        private IUserServices _userServices;

        public IndexModel(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public IEnumerable<Product> Products { get; set; }
        public void OnGet()
        {
            Products = _userServices.GetAllProducts();
        }

        public void OnPost()
        {

        }
    }
}
