using System;
using System.Windows;
using System.Windows.Controls;
using Dentistry_CRM.ViewModels;


namespace Dentistry_CRM.Views
{
    public partial class MainWindow : Window
    {
        public ScheduleViewModel Vm { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Vm = new ScheduleViewModel();
        }

        private async void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = Calendar.SelectedDate;

            MessageBox.Show(selectedDate.Value.Date.ToShortDateString());
            
            await Vm.GetColl();

            FirstChair.ItemsSource = Vm.List;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
