using System;
using System.Windows;
using System.Windows.Controls;
using Dentistry_CRM.Models;
using Dentistry_CRM.ViewModels;

namespace Dentistry_CRM.Views
{
    public partial class ScheduleView : Page
    {
        public ScheduleViewModel ScheduleViewModel { get; set; }

        public ScheduleView()
        {
            InitializeComponent();
            ScheduleViewModel = new ScheduleViewModel();
            ScheduleViewModel.GetDayAppointments(DateTime.Now);
            this.DataContext = ScheduleViewModel;
        }

        private async void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedDate = Calendar.SelectedDate;

            try
            {
                await ScheduleViewModel.GetDayAppointments(selectedDate.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCreate_OnClick(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            var data = b.DataContext as ScheduleItem;
            Navigation.Navigation.Navigate(new Uri("Views/CreateAppointmentView.xaml", UriKind.RelativeOrAbsolute),data?.Time.ToString());
        }
    }
}
