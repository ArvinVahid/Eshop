using System.Threading;
using System.Threading.Tasks;
using Eshop.Core.Entities;

namespace Eshop.Core.Contracts
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetOrderById(int id, CancellationToken cancellationToken);
        Task AddOrder(Order order, CancellationToken cancellationToken);
        Task<Order> IsOrderFinally(int id, CancellationToken cancellationToken);
    }
}