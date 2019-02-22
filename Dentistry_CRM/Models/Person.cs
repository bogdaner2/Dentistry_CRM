using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dentistry_CRM.Models
{
    public class Person : Base
    {
        
        private string _fullname;
        private string _phone;
        private string _photo;

        public string Fullname
        {
            get => _fullname;
            set => SetProperty(ref _fullname, value);
        }

        public string Photo
        {
            get => _photo;
            set => SetProperty(ref _photo, value);
        }
        public string Phone
        {
            get => _phone;
            set => SetProperty(ref _phone, value);
        }

        public override string ToString()
        {
            return $"{Fullname} | {Phone}";
        }

    }
}
