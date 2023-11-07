using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
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

        public async Task OnGet(int id, CancellationToken cancellationToken)
        {
            Product = await _productServices.GetAdminProductById(id, cancellationToken);
        }
        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            var products = await _productServices.GetProductById(Product.Id, cancellationToken);
            var item = await _itemServices.GetItemById(Product.Id, cancellationToken);

            await _productServices.RemoveProduct(products, cancellationToken);
            await _itemServices.RemoveItem(item, cancellationToken);
            await _userServices.SaveChangeAsync(cancellationToken);

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", Product.Id + ".jpg");

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            return RedirectToPage("Index");

        }
    }
}
