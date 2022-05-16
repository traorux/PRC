using PRC.CORE.Media.Call.Types.Call;
using PRC.CORE.Media.Call.Types.Device;
using System.Collections.Generic;

namespace PRC.API.Models
{
    public class EventCall 
    {
        public string LoginName { get; init; }
        public string CallRef { get; init; }
        //public Cause Cause { get; init; }
        //public CallData CallData { get; init; }
        public string DeviceNumber { get; init; }
        public string  CallerNumber { get; set; }

        public string State { get; set; }

        public EventCall(string loginName, string callRef, string deviceNumber, string callerNumber)
        {
            LoginName = loginName;
            CallRef = callRef;
            DeviceNumber = deviceNumber;
            CallerNumber = callerNumber;


        }
        //public int MyProperty { get; set; }

        //public List<Leg> Legs { get; init; }
        //public List<Participant> Participants { get; init; }
        ///public List<DeviceCapabilities> DeviceCapabilities { get; init; }
    }
}
