using CommunityToolkit.Mvvm.ComponentModel;
using PasswordBreachChecker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PasswordBreachChecker.ViewModels
{
    partial class VaultDuplicatesViewModel : ObservableObject
    {
        [ObservableProperty]
        public partial ObservableCollection<string> DuplicatePasswords { get; set; } = [];

        [ObservableProperty]
        public partial ObservableCollection<ResultDetails> DuplicatePasswordUsages { get; set; } = [];

        [ObservableProperty]
        public partial string SelectedItem { get; set; } = string.Empty;

        private Dictionary<string, ObservableCollection<ResultDetails>> m_cache = [];

        internal VaultDuplicatesViewModel(VaultStats vaultStats)
        {
            foreach(var pair in vaultStats.PasswordMap)
            {
                if(pair.Value.Count > 1)
                {
                    DuplicatePasswords.Add(pair.Key);
                    m_cache[pair.Key] = [];
                    foreach(PasswordEntry entry in pair.Value)
                    {
                        ResultDetails result = new()
                        {
                            Name = entry.Name,
                            URL = entry.URL ?? "<>"
                        };

                        m_cache[pair.Key].Add(result);
                    }
                }
            }

            PropertyChanged += (o, e) =>
            {
                if(e.PropertyName == nameof(SelectedItem))
                {
                    if(SelectedItem != null && SelectedItem != string.Empty)
                    {
                        DuplicatePasswordUsages = m_cache[SelectedItem];
                    }
                }
            };
        }
    }
}
