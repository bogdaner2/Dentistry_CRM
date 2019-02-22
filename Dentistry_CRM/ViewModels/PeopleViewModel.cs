using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Dentistry_CRM.DAL;
using Dentistry_CRM.Models;
using Dentistry_CRM.MVVM;

namespace Dentistry_CRM.ViewModels
{
    public class PeopleViewModel : BindableBase
    {
        private UnitOfWork uow;
        private Patient _selectedPatient;
        private Doctor _selectedDoctor;
        private ObservableCollection<Patient> _patients;
        private ObservableCollection<Doctor> _doctors;
        private string _photoSrc;
        private string _phone;
        private string _name;

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

        public string PhotoSrc
        {
            get => _photoSrc;
            set => SetProperty(ref _photoSrc, value);
        }

        public string Phone
        {
            get => _phone;
            set => SetProperty(ref _phone, value);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

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

        public async Task<bool> CreateNewPerson(string peopleType)
        {
            if (PhotoSrc == String.Empty)
                PhotoSrc = "http://upenn.sigrho.com/static/website/img/brothers/default.png";

            if (peopleType == "doctor")
            {
                Doctors.Add(await uow.DoctorsRepository.CreateAsync(new Doctor { Fullname = Name , Phone =  Phone , Photo = PhotoSrc}));
            }
            else
            {
                Patients.Add(await uow.PatientRepository.CreateAsync(new Patient { Fullname = Name, Phone = Phone, Photo = PhotoSrc }));
            }

            PhotoSrc = String.Empty;

            return true;
        }
    }
}
