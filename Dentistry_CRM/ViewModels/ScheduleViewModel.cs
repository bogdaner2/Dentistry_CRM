using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Threading.Tasks;
using Dentistry_CRM.Models;

namespace Dentistry_CRM.ViewModels
{
    public class ScheduleViewModel : BaseViewModel
    {
        public readonly ObservableCollection<Reception> Receptions;
        public readonly ObservableCollection<Patient> Patients;

        public ScheduleViewModel()
        {
            //using (var db = new DentistryContext())
            //{
            //    //db.Receptions.Load();
            //    //Receptions = db.Receptions.Local;
            //    db.Patients.Load();
            //    Patients = db.Patients.Local;
            //}
        }

        public async Task AddNewPatient(Patient patient)
        {
            using (var db = new DentistryContext())
            {
                db.Ts.Add(new T
                {
                    str ="df",
                    test = new Test
                    {
                        name = "test"
                    }
                });
                await db.SaveChangesAsync();
            }      
        }

       
    }
}
