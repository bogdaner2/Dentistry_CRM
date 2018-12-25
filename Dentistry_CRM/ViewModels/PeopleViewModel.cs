using System.Collections.ObjectModel;
using Dentistry_CRM.Models;
using Dentistry_CRM.MVVM;

namespace Dentistry_CRM.ViewModels
{
    public class PeopleViewModel : BindableBase
    {
        public Patient SelectedPatient { get; set; }
        public ObservableCollection<Patient> Patients { get; set; }

        public PeopleViewModel()
        {
            
        }
    }
}
