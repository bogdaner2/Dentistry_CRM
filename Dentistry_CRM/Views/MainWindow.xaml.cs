using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Dentistry_CRM.Models;
using Dentistry_CRM.ViewModels;


namespace Dentistry_CRM.Views
{
    public partial class MainWindow : Window
    {
        public ScheduleViewModel _vm;
        public MainWindow()
        {
            InitializeComponent();
            _vm = new ScheduleViewModel();
            //Cabinet1List.ItemsSource = _vm.Patients;
        }

        private async void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            //DateTime? selectedDate = Calendar.SelectedDate;

            //MessageBox.Show(selectedDate.Value.Date.ToShortDateString());
            await _vm.AddNewPatient(new Patient
            {
                Dubt = "200",
                Fullname = "Bohdan",
                Phone = "0555555555"
            });
        }
    }
}
