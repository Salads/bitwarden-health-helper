using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PasswordBreachChecker.Services
{
    internal class HashServiceSHA_1 : IHashService
    {
        public string Hash(string input)
        {
            return Convert.ToHexString(SHA1.HashData(Encoding.UTF8.GetBytes(input)));
        }
    }
}
