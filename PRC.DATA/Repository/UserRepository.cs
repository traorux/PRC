using Microsoft.EntityFrameworkCore;
using PRC.CORE.Model;
using PRC.CORE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.DATA.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly PRCDbContext dbContext;


        public UserRepository(PRCDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        public async Task<bool> AddUser(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<User> UpdateUser(User user)
        {
            dbContext.Users.Update(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> Authenticate(string useremail, string password)
        {

            if (string.IsNullOrEmpty(useremail) || string.IsNullOrEmpty(password))
                return null;
            var user = await dbContext.Users.SingleOrDefaultAsync(x => x.UserEmail == useremail);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;
            return user;
        }

        public async Task<User> CreateUser(User user, string password)
        {

            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required");
            var resultUser = await dbContext.Users.AnyAsync(x => (x.Username == user.Username || x.UserEmail == user.UserEmail));
            if (resultUser)
                throw new Exception("UserEmail \"" + user.UserEmail +  "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await dbContext.Users.AddAsync(user);
                 dbContext.SaveChanges();

            return user;
        }

        public void DeleteUser(int IdUser)
        {
            var user = dbContext.Users.Find(IdUser);
            if (user != null)
            {
                dbContext.Users.Remove(user);
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await dbContext.Users.ToListAsync();
        }
        public Task<User> GetUserByNumber(string UserNumber)
        {
            return Task.FromResult(dbContext.Users.Where(c => (c.DeviceNumber.Equals(UserNumber))).FirstOrDefault());
        }

        public async Task<User> GetWithUsersById(int IdUser)
        {
            return await dbContext.Users
                   .Where(user => user.IdUser == IdUser)
                   .FirstOrDefaultAsync();
        }

        public void UpdateUserParam(User userParam, string password = null)
        {
            var user = dbContext.Users.Find(userParam.IdUser);

            if (user == null)
                throw new Exception("User not found");

            if (userParam.Username != user.Username)
            {
                if (dbContext.Users.Any(x => x.Username == userParam.Username))
                    throw new Exception("Username " + userParam.Username + " is already taken");
            }

            user.FirstName = userParam.FirstName;
            user.LastName = userParam.LastName;
            user.Username = userParam.Username;

            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            dbContext.Users.Update(user);
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
