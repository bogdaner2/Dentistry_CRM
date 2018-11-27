using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Dentistry_CRM.DAL;
using Dentistry_CRM.Models;

namespace Dentistry_CRM.ViewModels
{
    public class ScheduleViewModel : BaseViewModel
    {
        private readonly MongoRepository<Patient> _repository;
        public ObservableCollection<Patient> PatientsList { get; set; }

        public ScheduleViewModel()
        {
            IMongoDataContext context = new MongoDataContext();
            _repository = new MongoRepository<Patient>(context);
        }

        /// <summary>
        /// Free times files by empty appointments
        /// </summary>
        /// <returns></returns>
        public async Task GetDayAppointments()
        {
            PatientsList = new ObservableCollection<Patient>(await _repository.GetAllAsync());
            for (int i = 0; i < 12 - PatientsList.Count; i++)
            {
                PatientsList.Add(new Patient());
            }
            await _repository.CreateAsync(new Patient { Fullname = " TEST" });
        }

        public async Task AddAppointment(Appointment appointment)
        {
           //await _repository.CreateAsync()
        }
    }
}
