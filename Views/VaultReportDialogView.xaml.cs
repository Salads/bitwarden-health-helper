using PasswordBreachChecker.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasswordBreachChecker.Views
{
    /// <summary>
    /// Interaction logic for VaultReportDialog.xaml
    /// </summary>
    public partial class VaultReportDialog : Window
    {
        public VaultReportDialog()
        {
            InitializeComponent();
        }

        void SetVM(VaultReportDialogViewModel viewModel)
        {
            viewModel.PropertyChanged += VaultReportDialog_PropertyChanged;
            DataContext = viewModel;
        }

        private void VaultReportDialog_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var vm = DataContext as VaultReportDialogViewModel;
            if(e.PropertyName == nameof(VaultReportDialogViewModel.CurrentPage))
            {
                string newPagUri = "VaultOverviewPage.xaml";
                if (vm.CurrentPage == Pages.Breaches)
                {
                    newPagUri = "VaultBreachesPage.xaml";
                }
                else if(vm.CurrentPage == Pages.Duplicates)
                {
                    newPagUri = "VaultDuplicatesPage.xaml";
                }

                frame.Source = new Uri(newPagUri);
            }
        }
    }
}
