using System;
using System.Windows;
using System.Windows.Controls;
using Dentistry_CRM.Models;
using Dentistry_CRM.ViewModels;

namespace Dentistry_CRM.Views
{
    public partial class CheckView : Page
    {
        public CheckViewModel ViewModel { get; set; }
        public CheckView()
        {
            InitializeComponent();
            ViewModel = new CheckViewModel();
            PdfBrowser.Visibility = Visibility.Hidden;
            PdfBrowser.Navigate(new Uri("about:blank"));
        }
        //Preview check
        //Set debt to person
        public async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            PdfBrowser.Visibility = Visibility.Visible;
            var result = await ViewModel.Service.GenerateCheck(DateTime.Now, new Patient { Fullname = "Sasha Pupkin" });
            PdfBrowser.Navigate("C:/Users/Bohdan/Desktop/t.pdf");
            //PdfBrowser.NavigateToString(@"<HTML><IFRAME SCROLLING=""YES"" SRC=""C:/Users/Bohdan/Desktop/Sasha Pupkin.pdf""></IFRAME></HTML>");
            
        }
    }
}
