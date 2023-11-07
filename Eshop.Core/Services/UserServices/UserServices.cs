using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Eshop.Core.Contracts;
using Eshop.Core.Convertors;
using Eshop.Core.Entities;
using Eshop.Core.Services.Interfaces;
using Eshop.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Data.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> LoginUser(string email, string password, CancellationToken cancellationToken)
        {
            return await _userRepository.GetByEmailAndPasswordAsync(email, password, cancellationToken);
        }

        public async Task<bool> IsExistByEmail(string email, CancellationToken cancellationToken)
        {
            return await _userRepository.IsUserExistsByEmail(email, cancellationToken);
        }


        public async Task AddUser(User user, CancellationToken cancellationToken)
        {
            await _userRepository.Entities.AddAsync(user, cancellationToken);
        }
    }
}
