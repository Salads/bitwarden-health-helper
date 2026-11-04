using PasswordBreachChecker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordBreachChecker.Services
{
    internal interface IPasswordBreachCheckService
    {
        Task<Dictionary<string, int>> GetBreachedHashes(string hashPrefix);
    }
}
