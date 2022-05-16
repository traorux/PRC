using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PRC.CORE.Model.Media
{
    public class Call
    {

        [Key]
        public string Id { get; set; }
        public string agent { get; set; }
        public string customer { get; set; }
        public DateTime dateHeure { get; set; }

    }
}
