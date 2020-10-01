using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eshop.Core.Convertors;
using Eshop.Core.Entities;
using Eshop.Core.Services.Interfaces;
using Eshop.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Data.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly EshopContext _context;

        public UserServices(EshopContext context)
        {
            _context = context;
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.Include(p => p.Item).ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Include(i => i.Item)
                .SingleOrDefault(p => p.ItemId == id);
        }
        public Product GetAdminProductById(int id)
        {
            return _context.Products.SingleOrDefault(p => p.Id == id);
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
        public void AddProduct(Product product)
        {
            _context.Add(product);
        }

        public void AddItem(Item item)
        {
            _context.Add(item);
        }
        public void RemoveItem(Item item)
        {
            _context.Remove(item);
        }
        public Item GetItemById(int id)
        {
            return _context.Items.SingleOrDefault(i => i.Id == id);
        }

        public User LoginUser(string email, string password)
        {
            return _context.Users.SingleOrDefault(e => e.Email == EmailCleaner.CleanedEmail(email) && e.Password == password);
        }

        public bool IsExistByEmail(string email)
        {
            return _context.Users.Any(e => e.Email == EmailCleaner.CleanedEmail(email));
        }


        public void AddUser(User user)
        {
            _context.Add(user);
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders.SingleOrDefault(u => u.UserId == id && !u.IsFinaly);
        }

        public OrderDetail GetOrderDetail(Order order, Product product)
        {
            return _context.OrderDetails.SingleOrDefault(p => p.OrderId == order.OrderId && p.ProductId == product.Id);
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
        }

        public Order IsOrderFinally(int id)
        {
            return _context.Orders.Where(u => u.UserId == id && !u.IsFinaly).Include(p => p.OrderDetails)
                .ThenInclude(p => p.Product).FirstOrDefault();
        }

        public OrderDetail GetDetailId(int id)
        {
            return _context.OrderDetails.Find(id);
        }

        public void RemoveOrderDetail(OrderDetail detail)
        {
            _context.Remove(detail);
        }
    }
}
