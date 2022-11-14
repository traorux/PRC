using PRC.CORE.Model;
using PRC.CORE.Repository;
using PRC.CORE.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.SERVICE
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;

        }
        public async Task<User> CreateUser(User user, string password)
        {
            await userRepository.CreateUser(user, password);
            return user;
        }

        public async Task<User> Authenticate(string useremail, string password)
        {
            return await userRepository.Authenticate(useremail, password);
        }

        public void DeleteUser(int IdUser)
        {
            userRepository.DeleteUser(IdUser);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await userRepository.GetAllUsers();
        }

        public async Task<User> GetUserById(int IdUser)
        {
            return await userRepository.GetWithUsersById(IdUser);
        }
        public void UpdateUserParam(User user, string password = null)
        {
            userRepository.UpdateUserParam(user, password);
        }
        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

    }
}
