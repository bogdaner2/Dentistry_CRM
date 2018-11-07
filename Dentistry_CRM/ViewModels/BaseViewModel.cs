using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Dentistry_CRM.DAL;
using Dentistry_CRM.Models;

namespace Dentistry_CRM.ViewModels
{
    public class BaseViewModel
    {
        public ObservableCollection<Patient> list;
        public BaseViewModel()
        {
            list = new ObservableCollection<Patient>();
            list.Add(new Patient {Debt = 100});
            list.Add(new Patient());
            list.Add(new Patient());
            //MongoDataContext context = new MongoDataContext();
            //MongoRepository<Patient> patientCollection = new MongoRepository<Patient>(context);
            //list = new ObservableCollection<Patient>(patientCollection.GetAllAsync().Result);
        }
    }
}
