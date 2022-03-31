using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Media.Call.Types.Call
{
    public class CallData
    {
        //public PartyInfo InitialCalled { get; set; }
        public bool DeviceCall { get; set; }
        public bool Anonymous { get; set; }
        public MediaState State { get; set; }
        public RecordState RecordState { get; set; }
        public List<Tag> Tags { get; set; }
        public CallCapabilities Capabilities { get; set; }
        public string AssociateData { get; set; }
        public string AccountInfo { get; set; }
        //public AcdData acdCallData { get; set; }
    }
}
