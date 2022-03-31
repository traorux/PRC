using PRC.CORE.Media.Call.Types.Call;
using PRC.CORE.Media.Call.Types.Device;
using System.Collections.Generic;

namespace PRC.CORE.Media.Call.Events
{
    public class OnCallCreatedEvent 
    {
        public string LoginName { get; init; }
        public string CallRef { get; init; }
        public Cause Cause { get; init; }
        public CallData CallData { get; init; }
        public string Initiator { get; init; }
        public List<Leg> Legs { get; init; }
        public List<Participant> Participants { get; init; }
        public List<DeviceCapabilities> DeviceCapabilities { get; init; }
    }
}
