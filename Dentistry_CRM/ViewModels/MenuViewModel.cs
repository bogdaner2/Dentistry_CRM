using System;
using System.Collections.ObjectModel;
using System.Linq;
using Dentistry_CRM.Models;
using Dentistry_CRM.Services;
using MahApps.Metro.IconPacks;

namespace Dentistry_CRM.ViewModels
{
    public class MenuViewModel
    {
        private static readonly ObservableCollection<MenuItem> AppMenu = new ObservableCollection<MenuItem>();
        private static readonly ObservableCollection<MenuItem> AppOptionsMenu = new ObservableCollection<MenuItem>();

        public MenuViewModel()
        {          
            this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.CalendarAltSolid }, Text = "Расписание", NavigationDestination = new Uri("Views/ScheduleView.xaml", UriKind.RelativeOrAbsolute) });
            if (UserService.Role == 0)
            {
                this.OptionsMenu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.CogsSolid }, Text = "Настройки", NavigationDestination = new Uri("Views/SettingsView.xaml", UriKind.RelativeOrAbsolute) });
            }
            else
            {
                this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.MoneyCheckSolid }, Text = "Создать чек", NavigationDestination = new Uri("Views/CheckView.xaml", UriKind.RelativeOrAbsolute) });
            }
            this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.UsersSolid }, Text = "Пациенты", NavigationDestination = new Uri("Views/PatientsView.xaml", UriKind.RelativeOrAbsolute) });
            this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.SyringeSolid }, Text = "Услуги", NavigationDestination = new Uri("Views/ServicesView.xaml", UriKind.RelativeOrAbsolute) });
            this.OptionsMenu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.InfoCircleSolid }, Text = "Инфо", NavigationDestination = new Uri("Views/InfoView.xaml", UriKind.RelativeOrAbsolute) });
        }

        public ObservableCollection<MenuItem> Menu => AppMenu;

        public ObservableCollection<MenuItem> OptionsMenu => AppOptionsMenu;

        public object GetItem(object uri)
        {
            return null == uri ? null : this.Menu.FirstOrDefault(m => m.NavigationDestination.Equals(uri));
        }

        public object GetOptionsItem(object uri)
        {
            return null == uri ? null : this.OptionsMenu.FirstOrDefault(m => m.NavigationDestination.Equals(uri));
        }
    }
}
