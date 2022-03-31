using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Media.Call.Types.Call
{
    public class Leg
    {
        public class LegCapabilities
        {
            public bool Answer { get; set; }
            public bool Drop { get; set; }
            public bool Hold { get; set; }
            public bool Retrieve { get; set; }
            public bool Reconnect { get; set; }
            public bool Mute { get; set; }
            public bool UnMute { get; set; }
            public bool SendDtmf { get; set; }
            public bool SwitchDevice { get; set; }
        }
        public string DeviceId { get; set; }
        public MediaState State { get; set; }
        public bool RingingRemote { get; set; }
        public LegCapabilities Capabilities { get; set; }
    }
}
