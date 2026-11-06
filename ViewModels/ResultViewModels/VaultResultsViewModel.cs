using System;
using System.Collections.Generic;
using System.Security.RightsManagement;
using System.Text;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using PasswordBreachChecker.Models;

namespace PasswordBreachChecker.ViewModels
{
    partial class VaultResultsViewModel : ObservableObject
    {
        [ObservableProperty]
        public partial VaultStats Stats { get; set; }

        [ObservableProperty]
        public partial string OverviewText { get; private set; }

        internal VaultResultsViewModel(VaultStats vaultStats)
        {
            Stats = vaultStats;
            OverviewText = string.Format("{0}/{1} Passwords have problems!", Stats.TotalUniqueProblemPasswords, Stats.PasswordMap.Count);
        }
    }
}
