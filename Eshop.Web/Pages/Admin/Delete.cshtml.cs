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
        private IUserServices _userServices;

        public DeleteModel(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [BindProperty]
        public Product Product { get; set; }

        public void OnGet(int id)
        {
            Product = _userServices.GetAdminProductById(id);
        }
        public IActionResult OnPost()
        {
            var products = _userServices.GetProductById(Product.Id);
            var item = _userServices.GetItemById(Product.Id);

            _userServices.RemoveProduct(products);
            _userServices.RemoveItem(item);
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
