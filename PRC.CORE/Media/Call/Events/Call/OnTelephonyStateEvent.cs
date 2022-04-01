using PRC.CORE.Media.Call.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Media.Call.Events
{
    public class OnTelephonyStateEvent : O2GEvent
    {
        public string LoginName { get; init; }
        public TelephonicState State { get; init; }
    }
}
