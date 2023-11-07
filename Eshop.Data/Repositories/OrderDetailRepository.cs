using System.Threading;
using System.Threading.Tasks;
using Eshop.Core.Contracts;
using Eshop.Core.Entities;
using Eshop.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Data.Repositories
{
    public class OrderDetailRepository : BaseRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(EshopContext dbContext) : base(dbContext)
        {
        }


        public async Task AddOrderDetail(OrderDetail orderDetail, CancellationToken cancellationToken)
        {
            await AddAsync(orderDetail, cancellationToken);
        }

        public async Task<OrderDetail> GetDetailId(int id, CancellationToken cancellationToken)
        {
            return await GetByIdAsync(cancellationToken, id);
        }

        public async Task RemoveOrderDetail(OrderDetail detail, CancellationToken cancellationToken)
        {
            await DeleteAsync(detail, cancellationToken);
        }

        public async Task<OrderDetail> GetOrderDetail(Order order, Product product, CancellationToken cancellationToken)
        {
            return await Entities
                .SingleOrDefaultAsync(o => o.OrderId == order.Id && o.ProductId == product.Id,
                cancellationToken);
        }
    }
}