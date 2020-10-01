using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Eshop.Core.Entities;
using Eshop.Core.Services.Interfaces;
using Eshop.Web.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop.Web.Pages.Admin
{
    public class AddModel : PageModel
    {
        private IUserServices _userServices;

        public AddModel(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [BindProperty]
        public AdminAddEditViewModel Product { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var item = new Item()
            {
                Price = Product.Price,
                QuantityInStock = Product.QuantityInStock
            };

            _userServices.AddItem(item);
            _userServices.SaveChanges();

            var product = new Product()
            {
                Name = Product.Name,
                Item = item,
                Description = Product.Description
            };

            _userServices.AddProduct(product);
            _userServices.SaveChanges();
            product.ItemId = product.Id;
            _userServices.SaveChanges();

            if (Product.Picture?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", product.Id + ".jpg");
                using (var stream = new FileStream(filePath,FileMode.Create))
                {
                    Product.Picture.CopyTo(stream);
                }
            }

            return RedirectToPage("Index");
        }
    }
}
