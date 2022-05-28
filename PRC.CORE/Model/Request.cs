using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Model
{
    public class Request
    {
        public string IdRequest { get; set; }
        public string Motif { get; set; }
        public string status { get; set; }
        public Call Call { get; set; }
    }
}
