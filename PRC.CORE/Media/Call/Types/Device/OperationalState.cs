using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Media.Call.Types.Device
{
    public enum OperationalState
    {
        [EnumMember(Value = "IN_SERVICE")]
        InService,

        [EnumMember(Value = "OUT_OF_SERVICE")]
        OutOfService,

        [EnumMember(Value = "UNKNOWN")]
        Unknown
    }
}
