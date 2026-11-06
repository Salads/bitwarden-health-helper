using PasswordBreachChecker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordBreachChecker.Services
{
    internal interface IDialogService
    {
        void ShowVaultReportDialog(VaultStats vaultStats);
    }
}
