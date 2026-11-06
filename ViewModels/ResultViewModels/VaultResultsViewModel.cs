using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PasswordBreachChecker.Models;
using System;
using System.Collections.Generic;
using System.Security.RightsManagement;
using System.Text;

namespace PasswordBreachChecker.ViewModels
{
    partial class VaultResultsViewModel : ObservableObject
    {
        [ObservableProperty]
        public partial VaultStats Stats { get; set; }

        [ObservableProperty]
        public partial string OverviewText { get; private set; }

        [ObservableProperty]
        public partial string BreachesText {  get; private set; }

        [ObservableProperty]
        public partial string DuplicatesText {  get; private set; }

        private readonly Action m_showBreaches;
        private readonly Action m_showDuplicates;

        internal VaultResultsViewModel(VaultStats vaultStats, Action showBreaches, Action showDuplicates)
        {
            Stats = vaultStats;

            m_showBreaches = showBreaches;
            m_showDuplicates = showDuplicates;

            OverviewText = string.Format("{0}/{1} Passwords have problems!", Stats.TotalUniqueProblemPasswords, Stats.PasswordMap.Count);
            BreachesText = string.Format("{0} Breached Passwords - View Details", Stats.BreachedPasswords.Count);
            DuplicatesText = string.Format("{0} Duplicate Passwords - View Details", Stats.UniqueDuplicatePasswordsCount);
        }

        [RelayCommand] private void ShowBreaches() => m_showBreaches();
        [RelayCommand] private void ShowDuplicates() => m_showDuplicates();
    }
}
