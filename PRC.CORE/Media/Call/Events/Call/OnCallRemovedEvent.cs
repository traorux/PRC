using PRC.CORE.Media.Call.Types.Call;
using PRC.CORE.Media.Call.Types.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Media.Call.Events
{
    public class OnCallRemovedEvent : O2GEvent
    {
        public string LoginName { get; init; }
        public string CallRef { get; init; }
        public Cause Cause { get; init; }
        public string NewDestination { get; init; }
        public List<DeviceCapabilities> DeviceCapabilities { get; init; }
    }
}
