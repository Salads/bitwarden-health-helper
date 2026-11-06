using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace PasswordBreachChecker.Services
{
    class FrameNavigationService : IFrameNavigationService
    {
        private Frame? m_frame;

        public void Attach(Frame frame) => m_frame = frame;

        public void NavigateTo(object viewModel)
        {
            if (m_frame is null)
            {
                throw new InvalidOperationException("Navigation service is not attached to a Frame.");
            }

            m_frame.Navigate(viewModel);
        }

        public void GoBack()
        {
            if (m_frame?.CanGoBack == true)
            {
                m_frame.GoBack();
            }
        }
    }
}
