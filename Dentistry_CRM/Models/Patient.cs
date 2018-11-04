namespace Dentistry_CRM.Models
{
    public class Patient : Person
    {
        private string _dubt;

        public string Dubt
        {
            get => _dubt;
            set
            {
                _dubt = value;
                OnPropertyChanged("Dubt");
            }
        }
    }
}
