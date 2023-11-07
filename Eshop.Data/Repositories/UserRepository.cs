using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Eshop.Core.Entities;
using Eshop.Data.Context;
using Eshop.Core.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(EshopContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetByEmailAndPasswordAsync(string email, string password, CancellationToken cancellationToken)
        {
            return await TableNoTracking
                .SingleOrDefaultAsync(u => u.Email == email && u.Password == password, cancellationToken);
        }

        public async Task<bool> IsUserExistsByEmail(string email, CancellationToken cancellationToken)
        {
            return await TableNoTracking.AnyAsync(u => u.Email == email, cancellationToken);
        }

        public async Task SaveChangeAsync(CancellationToken cancellationToken)
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }
    }
}