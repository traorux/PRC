using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Media.Call.Types.Call
{
    public enum Cause
    {
        [EnumMember(Value = "ABANDONED")]
        Abandoned,

        [EnumMember(Value = "ALL_TRUNK_BUSY")]
        AllTrunkBusy,

        [EnumMember(Value = "BUSY")]
        Busy,

        [EnumMember(Value = "CLEARED")]
        Cleared,

        [EnumMember(Value = "PARTICIPANT_LEFT")]
        ParticipantLeft,

        [EnumMember(Value = "CONFERENCED")]
        Conferenced,

        [EnumMember(Value = "INVALID_NUMBER")]
        InvalidNumber,

        [EnumMember(Value = "DESTINATION_NOT_OBTAINABLE")]
        DestinationNotObtainable,

        [EnumMember(Value = "FORWARDED")]
        Forwarded,

        [EnumMember(Value = "PICKED_UP")]
        PickedUp,

        [EnumMember(Value = "REDIRECTED")]
        Redirected,

        [EnumMember(Value = "TRANSFERRED")]
        Transferred,

        [EnumMember(Value = "UNKNOWN")]
        Unknown,

        [EnumMember(Value = "PICKED_UP_TANDEM")]
        PickedUpTandem,

        [EnumMember(Value = "CALL_BACK")]
        CallBack,

        [EnumMember(Value = "RECALL")]
        Recall,

        [EnumMember(Value = "DISTRIBUTED")]
        Distributed,

        [EnumMember(Value = "SUPERVISOR_LISTENING")]
        SupervisorListening,

        [EnumMember(Value = "SUPERVISOR_INTRUSION")]
        SupervisorIntrusion,

        [EnumMember(Value = "SUPERVISOR_RESTRICT_INTRUSION")]
        SupervisorRestrictIntrusion,

        [EnumMember(Value = "NO_AVAILABLE_AGENT")]
        NoAvailableAgent,

        [EnumMember(Value = "LOCKOUT")]
        Lockout
    }
}
