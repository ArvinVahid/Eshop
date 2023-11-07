using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Eshop.Core.Entities;

namespace Eshop.Core.Services.Interfaces
{
    public interface IOrderServices
    {
        Task<Order> GetOrderById(int id, CancellationToken cancellationToken);
        Task AddOrder(Order order, CancellationToken cancellationToken);
        Task<Order> IsOrderFinally(int id, CancellationToken cancellationToken);

    }
}
