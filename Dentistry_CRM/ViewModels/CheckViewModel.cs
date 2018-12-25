using System.Collections.ObjectModel;
using Dentistry_CRM.Models;
using Dentistry_CRM.MVVM;
using Dentistry_CRM.Services;

namespace Dentistry_CRM.ViewModels
{
    public class CheckViewModel : BindableBase
    {
        public CheckService Service { get; set; }
        public ObservableCollection<Service> Services { get; set; }
        public CheckViewModel()
        {
            Service= new CheckService();
        }

        
    }
}
