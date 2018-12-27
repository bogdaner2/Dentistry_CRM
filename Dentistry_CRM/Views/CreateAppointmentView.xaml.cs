using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Dentistry_CRM.ViewModels;

namespace Dentistry_CRM.Views
{
    public partial class CreateAppointmentView : Page
    {
        //public ScheduleViewModel ScheduleViewModel { get; set; }
        public AppointmentViewModel AppointmentViewModel { get; set; }
        public CreateAppointmentView()
        {
            InitializeComponent();
            AppointmentViewModel = new AppointmentViewModel();
            AppointmentViewModel.Time = "Час прийому: " + Navigation.Navigation.PassedData.ToString();
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

        private void Button_Create_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
