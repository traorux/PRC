using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Media.Call.Types.Call
{
    public enum MediaState
    {
        [EnumMember(Value = "UNKNOWN")]
        Unknown,
 
        [EnumMember(Value = "OFF_HOOK")]
        OffHook,

        [EnumMember(Value = "IDLE")]
        Idle,

        [EnumMember(Value = "RELEASING")]
        Releasing,

        [EnumMember(Value = "DIALING")]
        Dialing,

        [EnumMember(Value = "HELD")]
        Held,

        [EnumMember(Value = "RINGING_INCOMING")]
        RingingIncoming,

        [EnumMember(Value = "RINGING_OUTGOING")]
        RingingOutgoing,

        [EnumMember(Value = "ACTIVE")]
        Active
    }
}
