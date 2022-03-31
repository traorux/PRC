using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Media.Call.Types.User
{
    public enum UserState
    {
        [EnumMember(Value = "FREE")]
        Free,

        [EnumMember(Value = "BUSY")]
        Busy,

        [EnumMember(Value = "UNKNOWN")]
        Unknown
    }
}
