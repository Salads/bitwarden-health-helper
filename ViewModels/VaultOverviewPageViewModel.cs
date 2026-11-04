using System;
using System.Collections.Generic;
using System.Security.RightsManagement;
using System.Text;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using PasswordBreachChecker.Models;

namespace PasswordBreachChecker.ViewModels
{
    partial class VaultOverviewPageViewModel : ObservableObject
    {
        [ObservableProperty]
        public partial uint TotalPasswords { get; set; } = 0;

        [ObservableProperty]
        public partial VaultStats Stats { get; set; };
    }
}
