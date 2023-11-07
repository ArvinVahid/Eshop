using System.Threading;
using System.Threading.Tasks;
using Eshop.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Data.Context
{
    public interface IEshopContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<CategoryToProduct> CategoryToProducts { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderDetail> OrderDetails { get; set; }
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken);
    }
}