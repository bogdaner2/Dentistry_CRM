using Dentistry_CRM.Models;
using Dentistry_CRM.Services;
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

        private async void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if(await UserService.Authorizate(new User { Login = login.Text,Password = password.Text}))
            {
                MainWindow mw = new MainWindow();         
                mw.Show();
                this.Close();
            }
            else
            {
                this.ShowMessageAsync("Помилка", "Користувача с таким логіном та паролем неіснує!");
            }
        }
    }
}
