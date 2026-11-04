using PasswordBreachChecker.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();

            EntryGrid.Loaded += (sender, e) =>
            {
                if(EntryGrid.ItemsSource is ObservableCollection<PasswordEntry> src)
                {
                    src.CollectionChanged += (object? sender, NotifyCollectionChangedEventArgs e) =>
                    {
                        RecalculateColumnWidths();
                    };
                }

                RecalculateColumnWidths();
            };
        }

        private void RecalculateColumnWidths()
        {
            EntryGrid.UpdateLayout();

            DataGridColumn url = EntryGrid.Columns[1];
            DataGridLength star = url.Width;
            url.Width = DataGridLength.Auto;
            url.Width = star;
        }
    }
}