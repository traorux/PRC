using PRC.CORE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Repository
{
    public interface IUserRepository
    {
        Task<bool> AddUser(User user);
        Task<User> UpdateUser(User user);

        Task<User> Authenticate(string username, string password);
        Task<User> CreateUser(User user, string password);
        Task<User> GetUserByNumber(string UserNumber);
        void UpdateUserParam(User user, string password = null);
        void DeleteUser(int IdUser);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetWithUsersById(int IdUser);
    }
}
