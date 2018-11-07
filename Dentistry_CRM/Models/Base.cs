using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dentistry_CRM.Models
{
    public class Base : INotifyPropertyChanged
    {
        public Guid Id { get; set; }

        public Base()
        {
            Id = Guid.NewGuid();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
