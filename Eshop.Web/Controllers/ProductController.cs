using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eshop.Core.Services.Interfaces;
using Eshop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }


        [Route("/Groups/{id}/{name}")]
        public IActionResult GetProductByGroupId(int id, string name)
        {
            ViewData["GroupName"] = name;
            var products = _productServices.GetProductsByGroupId(id);
            return View(products);
        }
        
    }
}
