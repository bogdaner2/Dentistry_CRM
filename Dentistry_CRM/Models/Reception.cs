using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry_CRM.Models
{
    public class Reception : Base
    {
        private DateTime _time;
        private Patient _patient;
        private string _type;
        private string _color;

        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }
        public string Color
        {
            get => _color;
            set
            {
                _color = value;
                OnPropertyChanged("Color");
            }
        }
        public DateTime Time
        {
            get => _time;
            set
            {
                _time = value;
                OnPropertyChanged("Time");
            }
        }

        public Patient Patient
        {
            get => _patient;
            set
            {
                _patient = value;
                OnPropertyChanged("Patient");
            }
        }
    }
}
