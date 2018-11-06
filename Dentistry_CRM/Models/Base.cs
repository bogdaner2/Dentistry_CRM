using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dentistry_CRM.Models
{
    public class Base : INotifyPropertyChanged
    {
        private Guid _id;

        public Guid Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public Base()
        {
            this.Id = Guid.NewGuid();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
