using PRC.CORE.Media.Call.Types.Call;
using PRC.CORE.Media.Call.Types.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Media.Call.Events
{
    public class OnCallModifiedEvent
    {
        public string LoginName { get; init; }
        public string CallRef { get; init; }
        public Cause Cause { get; init; }
        public string PreviousCallRef { get; init; }
        public string ReplacedByCallRef { get; init; }
        public CallData CallData { get; init; }
        public List<Leg> ModifiedLegs { get; init; }
        public List<Leg> AddedLegs { get; init; }
        public List<Leg> RemovedLegs { get; init; }
        public List<Participant> ModifiedParticipants { get; init; }
        public List<DeviceCapabilities> DeviceCapabilities { get; init; }
        public List<string> RemovedParticipantIds { get; init; }
        public List<Participant> AddedParticipants { get; init; }
    }
}
