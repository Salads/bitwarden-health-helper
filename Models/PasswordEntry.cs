using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;

namespace PasswordBreachChecker.Models
{
    internal class PasswordEntry
    {
        public string Name { get; set; } = "<>";

        public string Login { get; set; } = "<>";

        public string? URL { get; set; } = "<>";

        public string? Password { get; set; } = "<>";

        public string? HashString { get; set; } = "<>";
    }
}
