using System.Windows;
using Dentistry_CRM.DAL;

namespace Dentistry_CRM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Seed.SeedData();
        }
    }
}
