using System;
using System.Windows;
using System.Windows.Controls;
using Dentistry_CRM.Models;
using Dentistry_CRM.ViewModels;

namespace Dentistry_CRM.Views
{
    public partial class CheckView : Page
    {
        public CheckViewModel CheckViewModel { get; set; }
        public CheckView()
        {

            InitializeComponent();
            CheckViewModel = new CheckViewModel();

            this.DataContext = CheckViewModel;
            PdfBrowser.Visibility = Visibility.Hidden;
            PdfBrowser.Navigate(new Uri("about:blank"));
        }

        private async void CreateCheck(object sender, RoutedEventArgs e)
        {
            CheckViewModel.GenerateCheck();
            PdfBrowser.Visibility = Visibility;
            PdfBrowser.Navigate($"{Environment.CurrentDirectory}/{CheckViewModel.PatientName}.pdf");
        }

        private void RemoveItem(object sender, RoutedEventArgs e)
        {
            CheckViewModel.RemoveService();
        }

        private void AddItem(object sender, RoutedEventArgs e)
        {
            CheckViewModel.SelectService();
        }
    }
}
