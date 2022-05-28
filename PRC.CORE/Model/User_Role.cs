using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Model
{
    public class User_Role
    {
        public int IdRole { get; set; }
        public int IdUser { get; set; }
        public Role Role { get; set; }
        public User User { get; set; }
    }
}
