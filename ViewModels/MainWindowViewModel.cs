using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.Extensions.DependencyInjection;
using PasswordBreachChecker.Services;
using PasswordBreachChecker.Models;

namespace PasswordBreachChecker.ViewModels
{
    internal partial class MainWindowViewModel : ObservableValidator
    {
        [Required]
        [CustomValidation(typeof(MainWindowViewModel), nameof(ValidateDataFilePath))]
        [ObservableProperty]
        public partial string DataFilePath { get; set; } = string.Empty;

        public ObservableCollection<PasswordEntry> Data { get; set; } = new ObservableCollection<PasswordEntry>();

        private VaultStats m_vaultStats = new();

        public MainWindowViewModel()
        {
#if DEBUG_MOCK
            DataFilePath = Path.Combine(AppContext.BaseDirectory, "MockData", "mockvault.csv");
            RefreshTable();
#endif
        }

        [RelayCommand(CanExecute = nameof(CanBrowse))]
        public void BrowseForFile()
        {
            IFileSelectorService fss = App.Current.Services.GetService<IFileSelectorService>()!;
            string? file = fss.BrowseForFile("CSV File|*.csv");
            if(file != null)
            {
                DataFilePath = file;
                RefreshTable();
            }
        }

        bool CanBrowse()
        {
#if DEBUG_MOCK
            return false;
#else
            return true;
#endif
        }

        [RelayCommand]
        public async Task CheckPasswords()
        {
            // Get minimized breached hashes from API
            IPasswordBreachCheckService pcs = App.Current.Services.GetService<IPasswordBreachCheckService>()!;
            Dictionary<string, int> breachedHashes = new();

            foreach(string requestHash in m_vaultStats.HashPrefixes)
            {
                Dictionary<string, int> requestHashes = await pcs.GetBreachedHashes(requestHash);
                foreach (var pair in requestHashes)
                {
                    breachedHashes[pair.Key] = pair.Value;
                }
            }

            // Flag breached entries in the vault
            foreach(var pair in m_vaultStats.PasswordMap)
            {
                if (breachedHashes.ContainsKey(pair.Value[0].HashString!))
                {
                    m_vaultStats.BreachedPasswords.Add(pair.Key);
                }
            }

            // Show Dialog with results.
            IDialogService ds = App.Current.Services.GetService<IDialogService>()!;
            ds.ShowVaultReportDialog(m_vaultStats);
        }

        public static ValidationResult ValidateDataFilePath(string name, ValidationContext context)
        {
            MainWindowViewModel instance = (MainWindowViewModel)context.ObjectInstance;

            if(File.Exists(name))
            {
                return ValidationResult.Success!;
            }
            else
            {
                return new ValidationResult("File does not exist!");
            }
        }

        private void RefreshTable()
        {
            Data.Clear();

            IHashService hs = App.Current.Services.GetService<IHashService>()!;

            using (StreamReader reader = File.OpenText(DataFilePath))
            {
                int nameIdx = 3;
                int urlIdx = 8;
                int loginIdx = 9;
                int passIdx = 10;
                bool hasColumnHeaders = true;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine()!;
                    if(hasColumnHeaders)
                    {
                        hasColumnHeaders = false;
                        continue;
                    }

                    var values = line.Split(',');

                    PasswordEntry entry = new PasswordEntry
                    {
                        Name = values[nameIdx],
                        URL = values[urlIdx],
                        Login = values[loginIdx],
                        Password = values[passIdx],
                        HashString = hs.Hash(values[passIdx])
                    };

                    m_vaultStats.AddEntry(entry);

                    Data.Add(entry);
                }
            }
        }
    }
}
