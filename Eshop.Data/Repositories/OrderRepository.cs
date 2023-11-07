using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Eshop.Core.Contracts;
using Eshop.Core.Entities;
using Eshop.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Data.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(EshopContext dbContext) : base(dbContext)
        {
        }

        public async Task<Order> GetOrderById(int id, CancellationToken cancellationToken)
        {
            return await Entities.Include(o => o.OrderDetails)
                .SingleOrDefaultAsync(o => o.Id == id, cancellationToken);
        }
        public async Task AddOrder(Order order, CancellationToken cancellationToken)
        {
            await AddAsync(order, cancellationToken);
        }
        public async Task<Order> IsOrderFinally(int id, CancellationToken cancellationToken)
        {
            return await TableNoTracking.Where(u => u.UserId == id && !u.IsFinaly)
                .Include(p => p.OrderDetails)
                .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}