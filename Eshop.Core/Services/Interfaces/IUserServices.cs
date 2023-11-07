using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Eshop.Core.Entities;

namespace Eshop.Core.Services.Interfaces
{
    public interface IUserServices
    {
        Task<User> LoginUser(string email, string password, CancellationToken cancellationToken);
        Task<bool> IsExistByEmail(string email, CancellationToken cancellationToken);
        Task AddUser(User user, CancellationToken cancellationToken);

    }
}
