using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRC.API.Resources
{
    public class RoleResource
    {
        public int IdRole { get; set; }
        public bool isAdmin { get; set; }
        public bool isSupervisor { get; set; }
        public bool isUser { get; set; }
        public bool isReporter { get; set; }
    }
}
