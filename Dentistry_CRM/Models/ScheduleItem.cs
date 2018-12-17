using System;
using Dentistry_CRM.MVVM;

namespace Dentistry_CRM.Models
{
    public class ScheduleItem : BindableBase
    {
        private DateTime _time;
        private string _debt;
        private string _patientName;
        private string _doctorName;
        private string _phone;
        private string _color;

        public DateTime Time
        {
            get => _time;
            set => SetProperty(ref _time, value);
        }
        public string PatientName
        {
            get => _patientName;
            set => SetProperty(ref _patientName, value);
        }
        public string DoctorName
        {
            get => _doctorName;
            set => SetProperty(ref _doctorName, value);
        }
        public string Color
        {
            get => _color;
            set => SetProperty(ref _color, value);
        }
        public string Debt
        {
            get => _debt;
            set => SetProperty(ref _debt, value);
        }

        public string Phone
        {
            get => _phone;
            set => SetProperty(ref _phone, value);
        }
    }
}
