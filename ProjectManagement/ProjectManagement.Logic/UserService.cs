

using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;

namespace ProjectManagement.Logic
{
    public class UserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }   

        public User Get(string id)
        {
            return userRepository.FindByCondition(u => u.Id == id).FirstOrDefault();
        }
    }
}
