using System;
using System.Collections.ObjectModel;
using System.Linq;
using Dentistry_CRM.DAL;
using Dentistry_CRM.Models;
using Dentistry_CRM.MVVM;
using Dentistry_CRM.Services;

namespace Dentistry_CRM.ViewModels
{
    public class CheckViewModel : BindableBase
    {
        private CheckService _service;
        private UnitOfWork _uow;
        private ObservableCollection<Service> _services;
        private ObservableCollection<Service> _selectedServices;
        private Service _selectedService;
        private string _patientName;

        public ObservableCollection<Service> Services
        {
            get => _services;
            set => SetProperty(ref _services, value);
        }
        public ObservableCollection<Service> SelectedServices
        {
            get => _selectedServices;
            set => SetProperty(ref _selectedServices, value);
        }
        public Service SelectedService
        {
            get => _selectedService;
            set => SetProperty(ref _selectedService, value);
        }
        public string PatientName
        {
            get => _patientName;
            set => SetProperty(ref _patientName, value);
        }


        public CheckViewModel()
        {
            _uow = new UnitOfWork();
            LoadData();
            _service = new CheckService();
        }
        private async void LoadData()
        {
            SelectedServices = new ObservableCollection<Service>();
            Services = new ObservableCollection<Service>(await _uow.ServiceRepository.GetAllAsync());
        }

        public void SelectService()
        {
            SelectedServices.Add(SelectedService);
        }

        public void RemoveService()
        {
            SelectedServices.Remove(SelectedService);
        }

        public async void GenerateCheck()
        {
           if(SelectedServices.Count != 0)
               await _service.GenerateCheck(DateTime.Now, PatientName,SelectedServices.ToList());
        }


    }
}
