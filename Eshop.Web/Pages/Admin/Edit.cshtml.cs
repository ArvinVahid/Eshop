using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Eshop.Core.Services.Interfaces;
using Eshop.Data.Context;
using Eshop.Web.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Web.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly IUserServices _userServices;
        private readonly IItemServices _itemServices;
        private readonly IProductServices _productServices;

        public EditModel(IUserServices userServices, IItemServices itemServices, IProductServices productServices)
        {
            _userServices = userServices;
            _itemServices = itemServices;
            _productServices = productServices;
        }

        [BindProperty]
        public AdminAddEditViewModel Product { get; set; }
        public async Task OnGet(int id,CancellationToken cancellationToken)
        {
            Product = await _productServices.GetAllProducts()
                .Where(p => p.Id == id)
                .Select(s => new AdminAddEditViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    QuantityInStock = s.Item.QuantityInStock,
                    Price = s.Item.Price
                }).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var products = await _productServices.GetProductById(Product.Id, cancellationToken);
            var item = await _itemServices.GetItemById(Product.Id, cancellationToken);

            products.Name = Product.Name;
            products.Description = Product.Description;

            item.Price = Product.Price;
            item.QuantityInStock = Product.QuantityInStock;
            await _userServices.SaveChangeAsync(cancellationToken);

            if (Product.Picture?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", Product.Id + ".jpg");
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Product.Picture.CopyTo(stream);
                }
            }
            return RedirectToPage("index");

        }
    }
}
