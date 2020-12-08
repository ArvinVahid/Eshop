using System;
using System.Collections.Generic;
using System.Text;

namespace Eshop.Core.Convertors
{
    public static class ConvertToPersian
    {
        public static string ToPersianKafYa(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            return str.Replace("ي", "ی").Replace("ك", "ک");
        }
    }
}
