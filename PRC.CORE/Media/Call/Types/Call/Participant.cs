using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Media.Call.Types.Call
{
    public class Participant
    {
        public string ParticipantId { get; set; }
        //public PartyInfo Identity { get; set; } //Dans Types/Common
        public bool Anonymous { get; set; }
        public bool Undroppable { get; set; }
        public MediaState State { get; set; }
    }
}
