using System.Collections.ObjectModel;
using Dentistry_CRM.DAL;
using Dentistry_CRM.Models;
using Dentistry_CRM.MVVM;

namespace Dentistry_CRM.ViewModels
{
    public class PeopleViewModel : BindableBase
    {
        private Patient _selectedPatient;
        private Doctor _selectedDoctor;
        private ObservableCollection<Patient> _patients;
        private ObservableCollection<Doctor> _doctors;

        public Patient SelectedPatient
        {
            get => _selectedPatient;
            set => SetProperty(ref _selectedPatient, value);
        }
        public Doctor SelectedDoctor
        {
            get => _selectedDoctor;
            set => SetProperty(ref _selectedDoctor, value);
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

        private UnitOfWork uow;

        public PeopleViewModel()
        {
            uow = new UnitOfWork();
            LoadData();
        }

        private async void LoadData()
        {
            Doctors = new ObservableCollection<Doctor>(await uow.DoctorsRepository.GetAllAsync());
            Patients = new ObservableCollection<Patient>(await uow.PatientRepository.GetAllAsync());
            SelectedDoctor = Doctors[0];
            SelectedPatient = Patients[0];
        }
    }
}
