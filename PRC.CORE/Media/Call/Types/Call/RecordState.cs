using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Media.Call.Types.Call
{
    public enum RecordState
    {
        [EnumMember(Value = "PAUSED")]
        Paused,

        [EnumMember(Value = "RECORDING")]
        Recording
    }
}
