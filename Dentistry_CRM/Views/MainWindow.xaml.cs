using System.Windows;
using System.Windows.Navigation;
using Dentistry_CRM.ViewModels;


namespace Dentistry_CRM.Views
{
    public partial class MainWindow : Window
    {
        public static NavigationService NavService;

        public MainWindow()
        {
            InitializeComponent();
            NavService = Main.NavigationService;
            NavService.Navigate(new ScheduleView());
        }

        private void BtnSchedule_OnClick(object sender, RoutedEventArgs e)
        {
            NavService.Navigate(new ScheduleView());
        }
    }
}
