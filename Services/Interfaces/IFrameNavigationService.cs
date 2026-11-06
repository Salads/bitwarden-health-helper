using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace PasswordBreachChecker.Services
{
    interface IFrameNavigationService
    {
        void Attach(Frame frame);
        void NavigateTo(object viewModel);
        void GoBack();
    }
}
