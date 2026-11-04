using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordBreachChecker.Models
{
    internal class BreachedHash
    {
        public string Hash { get; set; } = string.Empty;

        public int Instances { get; set; } = 0;
    }
}
