using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Model
{
    public class History
    {
        public string CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public string ExtensionNumber { get; set; }
        public string Motif { get; set; }
        public string Status { get; set; }
        public DateTime dateHeure { get; set; }
        public string AgentLastName { get; set; }
        public string AgentFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerFirstName { get; set; }
    }
}
