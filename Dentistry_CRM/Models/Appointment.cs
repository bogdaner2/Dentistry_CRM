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
            set
            {
                _time = value;
                OnPropertyChanged(nameof(Time));
            }
        }

        public Guid TypeId
        {
            get => _typeId;
            set
            {
                _typeId = value;
                OnPropertyChanged(nameof(TypeId));
            }
        }

        public Guid PatientId
        {
            get => _patientId;
            set
            {
                _patientId = value;
                OnPropertyChanged(nameof(PatientId));
            }
        }

        public int Chair
        {
            get => _chair;
            set
            {
                _chair = value;
                OnPropertyChanged(nameof(Chair));
            }
        }

        public List<Service> Services
        {
            get => _services;
            set
            {
                _services = value;
                OnPropertyChanged(nameof(Services));
            }
        }


    }
}
