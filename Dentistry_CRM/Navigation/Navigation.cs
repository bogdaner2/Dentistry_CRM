using System;
using System.Windows.Controls;

namespace Dentistry_CRM.Navigation
{
    public static class Navigation
    {
        private static Frame _frame;

        public static Frame Frame 
        {
            get => _frame; 
            set => _frame = value;
        }

        public static object PassedData { get; set; }


        public static bool Navigate(Uri sourcePageUri, object extraData = null)
        {
            if (_frame.CurrentSource != sourcePageUri)
            {
                PassedData = extraData;
                return _frame.Navigate(sourcePageUri, extraData);
            }
            return true;
        }

        public static bool Navigate(object content)
        {
            if (_frame.NavigationService.Content != content)
            {
                return _frame.Navigate(content);
            }
            return true;
        }

        public static void GoBack()
        {
            if (_frame.CanGoBack)
            {
                _frame.GoBack();
            }
        }
    }
}
