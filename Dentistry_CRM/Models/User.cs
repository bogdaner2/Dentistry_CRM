namespace Dentistry_CRM.Models
{
    public class User : Base
    {
        private string _login;
        private string _password;
        private Role _role;
        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public Role Role
        {
            get => _role;
            set => SetProperty(ref _role, value);
        }
    }

    public enum Role
    {
        Admin,
        Doctor
    }
}
