using System;
using System.Collections.Generic;
using System.Text;
using Eshop.Core.Entities;

namespace Eshop.Core.Services.Interfaces
{
    public interface IUserServices
    {
        List<Product> GetAllProducts();
        List<Category> GetAllCategories();
        Product GetProductById(int id);
        Product GetAdminProductById(int id);
        Item GetItemById(int id);
        void RemoveProduct(Product product);
        void RemoveItem(Item item);
        List<Product> GetProductsByGroupId(int id);
        User LoginUser(string email,string password);
        bool IsExistByEmail(string email);
        void AddUser(User user);
        void AddItem(Item item);
        void AddProduct(Product product);
        void SaveChanges();
        Order GetOrderById(int id);
        OrderDetail GetOrderDetail(Order order, Product product);
        void AddOrder(Order order);
        void AddOrderDetail(OrderDetail orderDetail);
        Order IsOrderFinally(int id);
        OrderDetail GetDetailId(int id);
        void RemoveOrderDetail(OrderDetail detail);
    }
}
