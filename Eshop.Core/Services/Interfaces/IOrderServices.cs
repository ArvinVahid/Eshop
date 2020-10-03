using System;
using System.Collections.Generic;
using System.Text;
using Eshop.Core.Entities;

namespace Eshop.Core.Services.Interfaces
{
    public interface IOrderServices
    {
        Order GetOrderById(int id);
        OrderDetail GetOrderDetail(Order order, Product product);
        void AddOrder(Order order);
        void AddOrderDetail(OrderDetail orderDetail);
        Order IsOrderFinally(int id);
        OrderDetail GetDetailId(int id);
        void RemoveOrderDetail(OrderDetail detail);
    }
}
