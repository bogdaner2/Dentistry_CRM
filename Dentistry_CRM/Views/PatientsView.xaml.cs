using System.Windows.Controls;
using Dentistry_CRM.ViewModels;

namespace Dentistry_CRM.Views
{
    /// <summary>
    /// Interaction logic for PatientsView.xaml
    /// </summary>
    public partial class PatientsView : Page
    {
        public PeopleViewModel PeopleViewModel { get; set; }
        public PatientsView()
        {
            InitializeComponent();
            PeopleViewModel = new PeopleViewModel();
            this.DataContext = PeopleViewModel;
            if (Navigation.Navigation.PassedData is string && Navigation.Navigation.PassedData == "create")
            {
                createTab.IsSelected = true;
            }
        }
    }
}
