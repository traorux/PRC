using PRC.CORE.Media.Call.Types.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Media.Call.Events
{
    public class OnDeviceStateModifiedEvent : O2GEvent
    {
        public String LoginName;
        public List<DeviceState> DeviceStates { get; init; }
    }
}
