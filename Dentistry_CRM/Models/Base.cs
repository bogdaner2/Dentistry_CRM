using System;
using Dentistry_CRM.MVVM;
using Dentistry_CRM.ViewModels;

namespace Dentistry_CRM.Models
{
    public class Base : BindableBase
    {
        private Guid _id;

        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public Base()
        {
            Id = Guid.NewGuid();
        }

    }
}
