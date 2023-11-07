using System.Threading;
using System.Threading.Tasks;
using Eshop.Core.Contracts;
using Eshop.Core.Entities;
using Eshop.Core.Services.Interfaces;

namespace Eshop.Core.Services.UserServices
{
    public class OrderDetailService : IOrderDetailServices
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task AddOrderDetail(OrderDetail orderDetail, CancellationToken cancellationToken)
        {
            await _orderDetailRepository.AddOrderDetail(orderDetail, cancellationToken);
        }

        public async Task<OrderDetail> GetDetailId(int id, CancellationToken cancellationToken)
        {
            return await _orderDetailRepository.GetDetailId(id, cancellationToken);
        }

        public async Task RemoveOrderDetail(OrderDetail detail, CancellationToken cancellationToken)
        {
            await _orderDetailRepository.RemoveOrderDetail(detail, cancellationToken);
        }

        public async Task<OrderDetail> GetOrderDetail(Order order, Product product, CancellationToken cancellationToken)
        {
            return await _orderDetailRepository.GetOrderDetail(order, product, cancellationToken);
        }
    }
}