using System;
using System.Collections.Generic;

namespace Dentistry_CRM.Models
{
    public class Appointment : Base
    {
        private DateTime _time;
        private Guid _typeId;
        private Guid _patientId;
        private int _chair;
        private List<Service> _services;

        public DateTime Time
        {
            get => _time;
            set => SetProperty(ref _time, value);
        }

        public Guid TypeId
        {
            get => _typeId;
            set => SetProperty(ref _typeId, value);
        }

        public Guid PatientId
        {
            get => _patientId;
            set => SetProperty(ref _patientId, value);
        }

        public int Chair
        {
            get => _chair;
            set => SetProperty(ref _chair, value);
        }

        public List<Service> Services
        {
            get => _services;
            set => SetProperty(ref _services, value);
        }


    }
}
