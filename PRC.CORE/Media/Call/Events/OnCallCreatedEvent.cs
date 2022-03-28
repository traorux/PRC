using PRC.CORE.Media.Call.Type;
using System.Collections.Generic;

namespace PRC.CORE.Media.Call.Events
{
    public class OnCallCreatedEvent 
    {
        public string DeviceNumber { get; init; }
        public string CalledNumber { get; set; }
        public string CallingNumber { get; set; }
        public CallType CallType { get; set; }
        public CallState CallState { get; set; }

    }
}
