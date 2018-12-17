using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Dentistry_CRM.Views
{
    /// <summary>
    /// Interaction logic for AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : MetroWindow
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.ShowMessageAsync("Помилка", "Користувача с таким логіном та паролем неіснує!");
        }
    }
}
