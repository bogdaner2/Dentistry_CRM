namespace Dentistry_CRM.Models
{
    public class Doctor : Person
    {
        private string _experience;

        public string Experience
        {
            get => _experience;
            set
            {
                _experience = value;
                OnPropertyChanged("Experience");
            }
        }
    }
}
