using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRC.API.Resources
{
    public class UserResource
    {
        public int IdUser { get; set; }
        //public int IdRole { get; set; }
        public string DeviceNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        //public RoleResource Role { get; set; }
    }
}
