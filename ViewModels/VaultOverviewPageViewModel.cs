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
        public partial VaultStats Stats { get; set; }

        public string GetOverviewText()
        {
            int totalBreachedPasswords = Stats.BreachedPasswords.Count;
            int totalDuplicatePasswords = Stats.UniqueDuplicatePasswordsCount;
            int totalUniquePasswords = Stats.PasswordMap.Count;

            int totalProblemPasswords = totalBreachedPasswords + totalDuplicatePasswords;

            return string.Format("{0}/{0} Passwords have problems!", totalProblemPasswords, totalUniquePasswords);
        }
    }
}
