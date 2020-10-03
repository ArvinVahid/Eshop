using System;
using System.Collections.Generic;
using System.Text;

namespace Eshop.Core.Convertors
{
    public class EmailCleaner
    {
        public static string CleanedEmail(string email)
        {
            return email.Trim().ToLower();
        }
    }
}
