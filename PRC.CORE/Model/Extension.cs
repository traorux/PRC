using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Model
{
    public class Extension
    {
        public string Number { get; set; }
        public string Password { get; set; }
        public ICollection<Call> Calls { get; set; }
    }
}
