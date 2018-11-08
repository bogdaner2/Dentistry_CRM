namespace Dentistry_CRM.Models
{
    public class Doctor : Person
    {
        private int _chair;

        public int Chair
        {
            get => _chair;
            set
            {
                _chair = value;
                OnPropertyChanged("Chair");
            }
        }
    }
}
