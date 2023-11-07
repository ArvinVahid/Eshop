using System.Threading;
using System.Threading.Tasks;
using Eshop.Core.Entities;

namespace Eshop.Core.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAndPasswordAsync(string email, string password, CancellationToken cancellationToken);
        Task<bool> IsUserExistsByEmail(string email, CancellationToken cancellationToken);
        Task SaveChangeAsync(CancellationToken cancellationToken);

    }
}