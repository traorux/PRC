using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Media.Call.Types.Device
{
    public class DeviceCapabilities
    {
        public string DeviceId { get; init; }
        public bool MakeCall { get; init; }
        public bool MakeBusinessCall { get; init; }
        public bool MakePrivateCall { get; init; }
        public bool UnParkCall { get; init; }
    }
}
