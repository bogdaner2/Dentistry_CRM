using System.Windows.Controls;

namespace Dentistry_CRM.Views
{
    /// <summary>
    /// Interaction logic for PatientsView.xaml
    /// </summary>
    public partial class PatientsView : Page
    {
        public PatientsView()
        {
            InitializeComponent();
            if ((string)Navigation.Navigation.PassedData == "create")
            {
                createTab.IsSelected = true;
            }
        }
    }
}
