using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Dentistry_CRM.Models;
using Dentistry_CRM.ViewModels;

namespace Dentistry_CRM.Views
{
    /// <summary>
    /// Interaction logic for ScheduleView.xaml
    /// </summary>
    public partial class ScheduleView : Page
    {
        public ScheduleViewModel Vm { get; set; }
        public ScheduleView()
        {
            InitializeComponent();
            
            Vm = new ScheduleViewModel();
        }

        private async void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = Calendar.SelectedDate;

            MessageBox.Show(selectedDate.Value.Date.ToShortDateString());

            await Vm.GetDayAppointments();

            FirstChair.ItemsSource = Vm.PatientsList;
        }

        private void BtnCreate_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.NavService.Navigate(new CreateAppointemtnView());
            MainWindow.NavService.RemoveBackEntry();
            //MessageBox.Show(((sender as Button).DataContext as Patient).Fullname);
        }
    }
}
