using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FunctionsNET.Extension
{
    public static class StringExtension
    {
        public static string Slug(this string value)
        {
            var result = RemoveAccent(value).Replace("-", " ").ToLowerInvariant();

            result = Regex.Replace(result, @"[^a-z0-9\s-]", string.Empty);
            result = Regex.Replace(result, @"\s+", " ").Trim();

            return Regex.Replace(result, @"\s", "-");
        }

        public static string RemoveAccent(this string value)
        {
            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value);
            return Encoding.ASCII.GetString(bytes);
        }

        public static bool IsEmail(this string value)
        {
            return Regex.IsMatch(value, @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,5})$");
        }
    }
}