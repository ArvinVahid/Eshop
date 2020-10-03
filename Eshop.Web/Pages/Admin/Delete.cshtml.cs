using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Eshop.Core.Entities;
using Eshop.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop.Web.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private readonly IUserServices _userServices;
        private readonly IItemServices _itemServices;
        private readonly IProductServices _productServices;

        public DeleteModel(IUserServices userServices, IItemServices itemServices, IProductServices productServices)
        {
            _userServices = userServices;
            _itemServices = itemServices;
            _productServices = productServices;
        }

        [BindProperty]
        public Product Product { get; set; }

        public void OnGet(int id)
        {
            Product = _productServices.GetAdminProductById(id);
        }
        public IActionResult OnPost()
        {
            var products = _productServices.GetProductById(Product.Id);
            var item = _itemServices.GetItemById(Product.Id);

            _productServices.RemoveProduct(products);
            _itemServices.RemoveItem(item);
            _userServices.SaveChanges();

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", Product.Id + ".jpg");

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            return RedirectToPage("Index");

        }
    }
}
