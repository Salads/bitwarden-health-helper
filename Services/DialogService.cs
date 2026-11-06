using Microsoft.Extensions.DependencyInjection;
using PasswordBreachChecker.Models;
using PasswordBreachChecker.ViewModels;
using PasswordBreachChecker.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordBreachChecker.Services
{
    internal class DialogService : IDialogService
    {
        public void ShowVaultReportDialog(VaultStats vaultStats)
        {
            IFrameNavigationService fns = App.Current.Services.GetService<IFrameNavigationService>()!;
            VaultReportDialogViewModel vm = new(vaultStats, fns);
            VaultReportDialogView resultDialog = new()
            {
                DataContext = vm,
                Owner = App.Current.MainWindow
            };

            resultDialog.ShowDialog();
        }
    }
}
