using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Eshop.Core.Services.Interfaces;
using Eshop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICategoryToProductServices _toProductServices;
        public ProductController(ICategoryToProductServices toProductServices)
        {
            _toProductServices = toProductServices;
        }
        
        [Route("/Groups/{id}/{name}")]
        public async Task<IActionResult> GetProductByGroupId(int id, string name, CancellationToken cancellationToken)
        {
            ViewData["GroupName"] = name;
            var products = await _toProductServices.GetProductsByGroupId(id, cancellationToken);
            return View(products);
        }
        
    }
}
