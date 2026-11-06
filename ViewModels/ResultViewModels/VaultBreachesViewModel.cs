using CommunityToolkit.Mvvm.ComponentModel;
using PasswordBreachChecker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PasswordBreachChecker.ViewModels
{
    partial class VaultBreachesViewModel : ObservableObject
    {
        [ObservableProperty]
        public partial ObservableCollection<string> BreachedPasswords { get; set; } = new();

        [ObservableProperty]
        public partial string SelectedItem {  get; set; } = string.Empty;

        [ObservableProperty]
        public partial ObservableCollection<ResultDetails> BreachedPasswordUsages { get; set; } = new();

        private Dictionary<string, ObservableCollection<ResultDetails>> m_cache = [];

        public VaultBreachesViewModel(VaultStats vaultStats)
        {
            foreach(string breachedPassword in vaultStats.BreachedPasswords)
            {
                BreachedPasswords.Add(breachedPassword);
                m_cache[breachedPassword] = [];
                foreach(PasswordEntry entry in vaultStats.PasswordMap[breachedPassword])
                {
                    ResultDetails resultDetails = new()
                    {
                        Name = entry.Name,
                        Login = entry.Login,
                        URL = entry.URL ?? "<>"
                    };
                    m_cache[breachedPassword].Add(resultDetails);
                }
            }

            PropertyChanged += (s, e) =>
            {
                if(e.PropertyName == nameof(SelectedItem))
                {
                    if(SelectedItem != string.Empty && SelectedItem != null)
                    {
                        BreachedPasswordUsages = m_cache[SelectedItem];
                    }
                }
            };
        }


    }
}
