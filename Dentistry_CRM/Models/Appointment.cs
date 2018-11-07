using System;

namespace Dentistry_CRM.Models
{
    public class Appointment : Base
    {
        private DateTime _time;
        private Guid _typeId;
        private Guid _patientId;
        private int _chair;

        public DateTime Time
        {
            get => _time;
            set
            {
                _time = value;
                OnPropertyChanged("Time");
            }
        }

        public Guid TypeId
        {
            get => _typeId;
            set
            {
                _typeId = value;
                OnPropertyChanged("TypeId");
            }
        }

        public Guid PatientId
        {
            get => _patientId;
            set
            {
                _patientId = value;
                OnPropertyChanged("PatientId");
            }
        }

        public int Chair
        {
            get => _chair;
            set
            {
                _chair = value;
                OnPropertyChanged("Chair");
            }
        }
    }
}
