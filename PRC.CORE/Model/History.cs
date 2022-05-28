using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Model
{
    public class History
    {
        public string CustomerNumbner { get; set; }
        public string CustomerName { get; set; }
        public string ExtensionNumber { get; set; }
        public string AgentName { get; set; }
        public string Motif { get; set; }
        public string Status { get; set; }
        public DateTime dateHeure { get; set; }
    }
}
