using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordBreachChecker.Services
{
    internal interface IHashService
    {
        string Hash(string input);
    }
}
