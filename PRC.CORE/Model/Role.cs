using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Model
{
    public class Role
    {
        
        public int IdRole { get; set; }
        public string Name { get; set; }
        public ICollection<User_Role> Users_Roles { get; set; }
    }
}
