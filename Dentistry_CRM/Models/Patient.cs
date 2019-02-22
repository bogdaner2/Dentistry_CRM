namespace Dentistry_CRM.Models
{
    public class Patient : Person
    {
        private int _debt;

        public int Debt
        {
            get => _debt;
            set => SetProperty(ref _debt,value);
        }
    }
}
