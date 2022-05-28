using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PRC.CORE.Model
{
    public class State
    {
        public int IdState { get; set; }
        public string CallRef { get; set; }
        public string Status { get; set; }
        public DateTime dateHeure { get; set; }
        public Call Call { get; set; }
    }
}
