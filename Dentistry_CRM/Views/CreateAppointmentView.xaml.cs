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
            //ScheduleViewModel = new ScheduleViewModel();
            AppointmentViewModel = new AppointmentViewModel();
            AppointmentViewModel.Time = Navigation.Navigation.PassedData.ToString();
            this.DataContext = AppointmentViewModel;
        }

    }
}
