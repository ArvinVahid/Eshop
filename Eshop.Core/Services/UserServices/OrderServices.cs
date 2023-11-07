using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Eshop.Core.Contracts;
using Eshop.Core.Entities;
using Eshop.Core.Services.Interfaces;
using Eshop.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Core.Services.UserServices
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepository _orderRepository;
        public OrderServices(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        
        public async Task<Order> GetOrderById(int id, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetOrderById(id, cancellationToken);
        }

        public async Task AddOrder(Order order, CancellationToken cancellationToken)
        {
            await _orderRepository.AddOrder(order, cancellationToken);
        }

        public async Task<Order> IsOrderFinally(int id, CancellationToken cancellationToken)
        {
            return await _orderRepository.IsOrderFinally(id, cancellationToken);
        }
    }
}
