using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FunctionsNET.Helper
{
    public static class RegexHelper
    {
        public static bool IsEmail(string email)
        {
            return Regex.IsMatch(email, @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,5})$");
        }
    }
}
