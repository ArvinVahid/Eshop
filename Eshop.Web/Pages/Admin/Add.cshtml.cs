using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
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
        private readonly  IUserServices _userServices;
        private readonly IItemServices _itemServices;
        private readonly IProductServices _productServices;

        public AddModel(IUserServices userServices, IItemServices itemServices, IProductServices productServices)
        {
            _userServices = userServices;
            _itemServices = itemServices;
            _productServices = productServices;
        }

        [BindProperty]
        public AdminAddEditViewModel Product { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
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

            await _itemServices.AddItem(item, cancellationToken);
            await _userServices.SaveChangeAsync(cancellationToken);

            var product = new Product()
            {
                Name = Product.Name,
                Item = item,
                Description = Product.Description
            };

            await _productServices.AddProduct(product, cancellationToken);
            await _userServices.SaveChangeAsync(cancellationToken);
            product.ItemId = product.Id;
            await _userServices.SaveChangeAsync(cancellationToken);

            if (Product.Picture?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", product.Id + ".jpg");
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Product.Picture.CopyTo(stream);
                }
            }

            return RedirectToPage("Index");
        }
    }
}
