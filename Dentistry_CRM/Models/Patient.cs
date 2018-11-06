using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry_CRM.Models
{
    public class Patient : Person
    {
        private string _dubt;
        private ICollection<Reception> _receptions;

        public string Dubt
        {
            get => _dubt;
            set
            {
                _dubt = value;
                OnPropertyChanged("Dubt");
            }
        }

        public ICollection<Reception> Receptions
        {
            get => _receptions;
            set
            {
                _receptions = value;
                OnPropertyChanged("Receptions");
            }
        }

        public Patient()
        {
            Receptions = new List<Reception>();
        }
    }
}
