using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordBreachChecker.Services
{
    internal interface IFileSelectorService
    {
        string? BrowseForFile(string filter);
    }
}
