using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PRC.CORE.Model
{
    public class Call
    {
        public Call()
        {
            States = new Collection<State>();
        }
        public string CallRef { get; set; }
        public string ExtensionNumber { get; set; }
        public int IdCustomer { get; set; }
        public string CustomerNumber { get; set; }
        public DateTime dateHeure { get; set; }
        public string typeCall { get; set; }
        public string removeParticipant { set; get; }
        public Extension Extension { get; set; }
        public Customer Customer { get; set; }
        public Request Request { get; set; }
        public ICollection<State> States { get; set; }
    }
}
