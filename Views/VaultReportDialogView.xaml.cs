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

            Loaded += (_, _) =>
            {
                if (DataContext is VaultReportDialogViewModel vm)
                {
                    vm.FrameNavigationService.Attach(frame);
                    vm.Start();
                }
            };
        }
    }
}
