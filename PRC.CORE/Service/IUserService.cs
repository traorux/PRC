using PRC.CORE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Service
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<User> CreateUser(User user, string password);
        void UpdateUserParam(User user, string password = null);
        void DeleteUser(int IdUser);
        Task<User> GetUserById(int IdUser);
    }
}
