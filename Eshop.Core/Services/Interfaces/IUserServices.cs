using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eshop.Core.Entities;

namespace Eshop.Core.Services.Interfaces
{
    public interface IUserServices
    {
        User LoginUser(string email, string password);
        bool IsExistByEmail(string email);
        void AddUser(User user);
        void SaveChanges();
        
    }
}
