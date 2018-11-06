using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dentistry_CRM.Models
{
    public class Person : Base
    {     
        private string _fullname;
        private string _phone;

        public string Fullname
        {
            get => _fullname;
            set
            {
                _fullname = value;
                OnPropertyChanged("Fullname");
            }
        }
        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }
    }
}
