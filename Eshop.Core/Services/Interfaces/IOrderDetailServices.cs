using System.Threading;
using System.Threading.Tasks;
using Eshop.Core.Entities;

namespace Eshop.Core.Services.Interfaces
{
    public interface IOrderDetailServices
    {
        Task AddOrderDetail(OrderDetail orderDetail, CancellationToken cancellationToken);
        Task<OrderDetail> GetDetailId(int id, CancellationToken cancellationToken);
        Task RemoveOrderDetail(OrderDetail detail, CancellationToken cancellationToken);
        Task<OrderDetail> GetOrderDetail(Order order, Product product, CancellationToken cancellationToken);
    }
}