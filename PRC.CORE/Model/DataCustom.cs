using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Model
{
    public class DataCustom
    {

        public int IdDataCustom { get; set; }
        public string NumeroCompte { get; set; }
        public string TypeVoiture { get; set; }
        public string DateVisiteTec { get; set; }
        public Customer Customer { get; set; }
    }
}
