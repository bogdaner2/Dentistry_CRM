using System;
using System.Collections.ObjectModel;
using Dentistry_CRM.DAL;
using Dentistry_CRM.Models;
using Dentistry_CRM.MVVM;

namespace Dentistry_CRM.ViewModels
{
    public class AppointmentViewModel : BindableBase
    {
        private UnitOfWork _uow;
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

        public AppointmentViewModel()
        {
            _uow = new UnitOfWork();
            LoadData(); 
        }

        public async void CreateAppointment(Appointment item)
        {
            item.Time = DateTime.Parse(Time);
            await _uow.AppointmentRepository.CreateAsync(item);
        }

        private async void LoadData()
        {
            Patients = new ObservableCollection<Patient>(await _uow.PatientRepository.GetAllAsync());
            Doctors = new ObservableCollection<Doctor>(await _uow.DoctorsRepository.GetAllAsync());
            Types = new ObservableCollection<TypeOfAppointment>(await _uow.TypesRepository.GetAllAsync());
        }
    }
}
