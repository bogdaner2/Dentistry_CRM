using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Dentistry_CRM.DAL;
using Dentistry_CRM.Models;

namespace Dentistry_CRM.ViewModels
{
    public class ScheduleViewModel : BaseViewModel
    {
        private readonly IMongoDataContext _context;
        private readonly IRepository<Patient> _repository;
        public ObservableCollection<Patient> List { get; set; }

        public ScheduleViewModel()
        {
            _context = new MongoDataContext();
            _repository = new MongoRepository<Patient>(_context);
        }

        public async Task GetColl()
        {
            List = new ObservableCollection<Patient>(await _repository.GetAllAsync());
        }

        public async Task AddAppointment(Appointment appointment)
        {
           //await _repository.CreateAsync()
        }
    }
}
