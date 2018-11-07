namespace Dentistry_CRM.Models
{
    public class Patient : Person
    {
        private int _debt;

        public int Debt
        {
            get => _debt;
            set
            {
                _debt = value;
                OnPropertyChanged("Debt");
            }
        }
    }
}
