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
            createTab.IsSelected = true;
        }
    }
}
