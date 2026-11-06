using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PasswordBreachChecker.Models;
using PasswordBreachChecker.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordBreachChecker.ViewModels
{
    enum Pages
    {
        Overview,
        Breaches,
        Duplicates
    }

    internal partial class VaultReportDialogViewModel : ObservableObject
    {
        [ObservableProperty]
        public partial Pages CurrentPage { get; private set; } = Pages.Overview;

        private VaultStats VaultStats { get; set; }

        VaultReportDialogViewModel(VaultStats vaultStats)
        {
            VaultStats = vaultStats;
        }

        [RelayCommand]
        public void SetPagePrevious()
        {
            CurrentPage = Pages.Overview;
        }

        [RelayCommand]
        public void SetPageBreaches()
        {
            CurrentPage = Pages.Breaches;
        }

        [RelayCommand]
        public void SetPageDuplicates()
        {
            CurrentPage = Pages.Duplicates;
        }
    }
}
