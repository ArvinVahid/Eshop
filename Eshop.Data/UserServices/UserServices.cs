using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eshop.Core.Convertors;
using Eshop.Core.Entities;
using Eshop.Core.Services.Interfaces;
using Eshop.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Data.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly EshopContext _context;

        public UserServices(EshopContext context)
        {
            _context = context;
        }

        public User LoginUser(string email, string password)
        {
            return _context.Users.SingleOrDefault(e => e.Email == EmailCleaner.CleanedEmail(email) && e.Password == password);
        }

        public bool IsExistByEmail(string email)
        {
            return _context.Users.Any(e => e.Email == EmailCleaner.CleanedEmail(email));
        }


        public void AddUser(User user)
        {
            _context.Add(user);
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        
    }
}
