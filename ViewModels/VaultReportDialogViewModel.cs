using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PasswordBreachChecker.Models;
using PasswordBreachChecker.Services;
using PasswordBreachChecker.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;

namespace PasswordBreachChecker.ViewModels
{
    internal partial class VaultReportDialogViewModel : ObservableObject
    {
        public IFrameNavigationService FrameNavigationService { get; }

        public VaultResultsViewModel ResultsVM { get; }

        public VaultBreachesViewModel BreachesVM { get; }

        public VaultDuplicatesViewModel DuplicatesVM { get; }

        [ObservableProperty]
        public partial VaultStats Stats { get; private set; }

        internal VaultReportDialogViewModel(VaultStats vaultStats, IFrameNavigationService frameNavigationService)
        {
            Stats = vaultStats;
            FrameNavigationService = frameNavigationService;

            BreachesVM = new VaultBreachesViewModel(vaultStats);
            DuplicatesVM = new VaultDuplicatesViewModel(vaultStats);
            ResultsVM = new VaultResultsViewModel(vaultStats, 
                () => FrameNavigationService.NavigateTo(BreachesVM),
                () => FrameNavigationService.NavigateTo(DuplicatesVM));
        }

        public void Start() => FrameNavigationService.NavigateTo(ResultsVM);

        [RelayCommand] private void GoBack() => FrameNavigationService.GoBack();

        [RelayCommand] private void ShowBreaches() => FrameNavigationService.NavigateTo(BreachesVM);

        [RelayCommand] private void ShowDuplicates() => FrameNavigationService.NavigateTo(DuplicatesVM);
    }
}
