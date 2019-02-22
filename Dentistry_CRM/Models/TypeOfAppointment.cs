namespace Dentistry_CRM.Models
{
    public class TypeOfAppointment : Base
    {
        private string _type;
        private string _color;

        public string Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }

        public string Color
        {
            get => _color;
            set => SetProperty(ref _color, value);
        }
    }
}
