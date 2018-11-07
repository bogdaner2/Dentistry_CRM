namespace Dentistry_CRM.Models
{
    public class TypeOfAppointment : Base
    {
        private string _type;
        private string _color;

        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }

        public string Color
        {
            get => _color;
            set
            {
                _color = value;
                OnPropertyChanged("Color");
            }
        }
    }
}
