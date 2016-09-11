using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace VeraControl.Extensions
{
    internal static class SecurityExtension
    {
        internal static string Sha1Hash(this string value)
        {
            var hashBytes = SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(value));

            var sb = new StringBuilder();

            foreach (var hexValue in hashBytes.Select(byteItem => byteItem.ToString("x2")))
            {
                sb.Append(hexValue);
            }

            return sb.ToString();
        }
    }
}
