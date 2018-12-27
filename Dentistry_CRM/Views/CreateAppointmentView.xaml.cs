using System;
using System.Windows;
using System.Windows.Controls;
using Dentistry_CRM.Models;
using Dentistry_CRM.ViewModels;

namespace Dentistry_CRM.Views
{
    public partial class CreateAppointmentView : Page
    {
        public AppointmentViewModel AppointmentViewModel { get; set; }
        public CreateAppointmentView()
        {
            InitializeComponent();
            AppointmentViewModel = new AppointmentViewModel();
            AppointmentViewModel.Time = Navigation.Navigation.PassedData.ToString();
            this.DataContext = AppointmentViewModel;
        }

        private void Button_Patient(object sender, RoutedEventArgs e)
        {
            Navigation.Navigation.Navigate(new Uri("Views/PatientsView.xaml", UriKind.RelativeOrAbsolute), "create" );
        }

        private void Button_Doctor(object sender, RoutedEventArgs e)
        {
            Navigation.Navigation.Navigate(new Uri("Views/PatientsView.xaml", UriKind.RelativeOrAbsolute), "create" );
        }

        private async void Button_Create_Click(object sender, RoutedEventArgs e)
        {
            AppointmentViewModel.CreateAppointment(new Appointment
            {
                PatientId = ((Patient)SelectedPatient.SelectedValue).Id,
                TypeId = ((TypeOfAppointment)SelectedType.SelectedValue).Id,
                Chair = chair1.IsChecked.Value 
                    ? 1 
                    : chair2.IsChecked.Value
                    ? 2
                    : 1
            });
        }
    }
}
