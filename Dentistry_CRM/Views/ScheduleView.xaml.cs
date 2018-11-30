using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Dentistry_CRM.Models;
using Dentistry_CRM.ViewModels;
using MahApps.Metro.Controls.Dialogs;

namespace Dentistry_CRM.Views
{
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
            var selectedDate = Calendar.SelectedDate;

            await Vm.GetDayAppointments();

            FirstChair.ItemsSource = Vm.PatientsList;
        }

        private void NavigateToAppointmentPage()
        {

        }

        private void BtnCreate_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
