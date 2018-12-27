using System.Threading.Tasks;
using Dentistry_CRM.DAL;
using Dentistry_CRM.Models;

namespace Dentistry_CRM.Services
{
    public static class UserService
    {
        public static Role Role { get; private set; }

        private static UnitOfWork uow;

        static UserService()
        {
            uow = new UnitOfWork();
        }

        public static Role SetRole(Role role)
        {
            Role = role;
            return Role;
        }

        public static async Task<bool> Authorizate(User user)
        {
            var res = await uow.UserRepository
                .GetAllAsync(x => x.Login == user.Login && x.Password == user.Password);

            if (res.Count == 1)
                SetRole(res[0].Role);

            return res.Count != 0;
        }
    }
}
