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
    public class OrderServices : IOrderServices
    {
        private readonly EshopContext _context;

        public OrderServices(EshopContext context)
        {
            _context = context;
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
