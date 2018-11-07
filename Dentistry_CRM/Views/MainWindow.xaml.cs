using System;
using System.Windows;
using System.Windows.Controls;
using Dentistry_CRM.DAL;
using Dentistry_CRM.Models;
using Dentistry_CRM.ViewModels;
using MongoDB.Driver;


namespace Dentistry_CRM.Views
{
    public partial class MainWindow : Window
    {
        public BaseViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new BaseViewModel();
            ///FirstChair.ItemsSource = vm.list;
        }

        private async void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = Calendar.SelectedDate;

            MessageBox.Show(selectedDate.Value.Date.ToShortDateString());

            //MongoDataContext context = new MongoDataContext();
            //MongoRepository<Patient> patientCollection = new MongoRepository<Patient>(context);
            //MongoRepository<Appointment> appCollection = new MongoRepository<Appointment>(context);
            //for (int i = 0; i < 3000; i++)
            //{
                
            
            //var patient = new Patient
            //{
            //    Fullname = "Богдан Конорин",
            //    Debt = 150
            //};
            //await patientCollection.CreateAsync(patient);
            //await appCollection.CreateAsync(
            //    new Appointment
            //    {
            //        Chair = 1,
            //        PatientId = patient.Id,
            //        Time = DateTime.Now
            //    });
            //}
        }
    }
}
