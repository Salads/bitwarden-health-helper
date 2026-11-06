using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordBreachChecker.Models
{
    internal partial class ResultDetails : ObservableObject
    {
        [ObservableProperty]
        public partial string Name {  get; set; } = string.Empty;

        [ObservableProperty]
        public partial string URL {  get; set; } = string.Empty;
    }
}
