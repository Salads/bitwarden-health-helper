using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace PasswordBreachChecker.Services
{
    internal class FileSelectorNET : IFileSelectorService
    {
        public string? BrowseForFile(string filter)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = filter;

            bool? result = dialog.ShowDialog();
            if(result == true)
            {
                return dialog.FileName;
            }
            else
            {
                return null;
            }
        }
    }
}
