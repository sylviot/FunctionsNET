using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FunctionsNET.MethodExtension
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

        /// 
        /// Regex Validation in String Extension
        /// 
        public static bool IsEmail(this string value)
        {
            return Regex.IsMatch(value, @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,5})$");
        }

        public static bool IsUrl(this string value)
        {
            return Regex.IsMatch(value, @"\b((?:[a-z][\w-]+:(?:/{1,3}|[a-z0-9%])|www\d{0,3}[.]|[a-z0-9.\-]+[.][a-z]{2,4}/)(?:[^\s()<>]+|\(([^\s()<>]+|(\([^\s()<>]+\)))*\))+(?:\(([^\s()<>]+|(\([^\s()<>]+\)))*\)|[^\s`!()\[\]{};:'" + "\".,<>?«»“”‘’]))");
        }

    }
}