using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PasswordBreachChecker.ViewModels
{
    partial class GenericOneToManyPageViewModel : ObservableObject
    {
        [ObservableProperty]
        public partial ObservableCollection<string> DataOne { get; set; }

        [ObservableProperty]
        public partial ObservableCollection<string> DataMany { get; set; }

        private Dictionary<string, List<string>> OneToManyMap = [];

        [ObservableProperty]
        public partial string OneHeader { get; set; } = "Passwords";

        [ObservableProperty]
        public partial string ManyHeader { get; set; } = "Usages";

        public void SetData(Dictionary<string, List<string>> data, string oneHeader = "Passwords", string manyHeader = "Usages")
        {
            OneToManyMap = data;
            DataOne.Clear();
            DataOne = (ObservableCollection<string>)DataOne.Union(data.Keys);

            OneHeader = oneHeader;
            ManyHeader = manyHeader;
        }
    }
}
