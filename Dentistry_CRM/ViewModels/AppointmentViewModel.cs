using System.Collections.ObjectModel;
using Dentistry_CRM.DAL;
using Dentistry_CRM.Models;
using Dentistry_CRM.MVVM;

namespace Dentistry_CRM.ViewModels
{
    public class AppointmentViewModel : BaseViewModel
    {
        private string _time;
        private ObservableCollection<Patient> _patients;
        private ObservableCollection<Doctor> _doctors;
        private ObservableCollection<TypeOfAppointment> _types;
        public string Time
        {
            get => _time;
            set => SetProperty(ref _time, value);
        }

        public ObservableCollection<Patient> Patients
        {
            get => _patients;
            set => SetProperty(ref _patients, value);
        }

        public ObservableCollection<Doctor> Doctors
        {
            get => _doctors;
            set => SetProperty(ref _doctors, value);
        }

        public ObservableCollection<TypeOfAppointment> Types
        {
            get => _types;
            set => SetProperty(ref _types, value);
        }

        private readonly MongoRepository<Patient> _patientRepository;
        private readonly MongoRepository<Doctor> _doctorRepository;
        private readonly MongoRepository<TypeOfAppointment> _typeRepository;

        public AppointmentViewModel()
        {
            IMongoDataContext context = new MongoDataContext();
            _patientRepository = new MongoRepository<Patient>(context);
            _doctorRepository = new MongoRepository<Doctor>(context);
            _typeRepository = new MongoRepository<TypeOfAppointment>(context);
            LoadData(); 
        }

        public async void LoadData()
        {
            Patients = new ObservableCollection<Patient>(await _patientRepository.GetAllAsync());
            Doctors = new ObservableCollection<Doctor>(await _doctorRepository.GetAllAsync());
            Types = new ObservableCollection<TypeOfAppointment>(await _typeRepository.GetAllAsync());
        }
    }
}
