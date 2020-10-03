using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eshop.Core.Entities;
using Eshop.Core.Services.Interfaces;
using Eshop.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Data.UserServices
{
    public class ProductServices : IProductServices
    {
        private readonly EshopContext _context;

        public ProductServices(EshopContext context)
        {
            _context = context;
        }
        public void AddProduct(Product product)
        {
            _context.Add(product);
        }

        public Product GetAdminProductById(int id)
        {
            return _context.Products.SingleOrDefault(p => p.Id == id);
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public IQueryable<Product> GetAllProducts()
        {
            return _context.Products.Include(p => p.Item);
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Include(i => i.Item)
                .SingleOrDefault(p => p.ItemId == id);
        }

        public List<Product> GetProductsByGroupId(int id)
        {
            return _context.CategoryToProducts
                .Where(c => c.CategoryId == id)
                .Include(p => p.Product)
                .Select(p => p.Product).ToList();
        }

        public void RemoveProduct(Product product)
        {
            _context.Remove(product);
        }
    }
}
