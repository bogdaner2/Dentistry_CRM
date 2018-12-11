namespace Dentistry_CRM.Models
{
    public class Service : Base
    {
        private string _name;
        private double _price;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public double Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }
    }
}
