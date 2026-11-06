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
    enum Pages
    {
        Overview,
        Breaches,
        Duplicates
    }

    internal partial class VaultReportDialogViewModel : ObservableObject
    {
        public IFrameNavigationService FrameNavigationService { get; }

        public VaultResultsViewModel ResultsVM { get; }

        public VaultBreachesViewModel BreachesVM { get; }

        public VaultDuplicatesViewModel DuplicatesVM { get; }

        private VaultStats VaultStats { get; set; }

        internal VaultReportDialogViewModel(VaultStats vaultStats, IFrameNavigationService frameNavigationService)
        {
            VaultStats = vaultStats;
            FrameNavigationService = frameNavigationService;

            ResultsVM = new VaultResultsViewModel(vaultStats);
            BreachesVM = new VaultBreachesViewModel(vaultStats);
            DuplicatesVM = new VaultDuplicatesViewModel(vaultStats);

            FrameNavigationService.NavigateTo(ResultsVM);
        }

        public void Start() => FrameNavigationService.NavigateTo(ResultsVM);

        [RelayCommand] private void GoBack() => FrameNavigationService.GoBack();

        [RelayCommand] private void ShowBreaches() => FrameNavigationService.NavigateTo(BreachesVM);

        [RelayCommand] private void ShowDuplicates() => FrameNavigationService.NavigateTo(DuplicatesVM);
    }
}
