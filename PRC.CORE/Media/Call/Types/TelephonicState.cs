using PRC.CORE.Media.Call.Types.Device;
using PRC.CORE.Media.Call.Types.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Media.Call.Types
{
    public class TelephonicState
    {
        public List<PbxCall> Calls { get; set; }
        public List<DeviceCapabilities> DeviceCapabilities { get; set; }

        public UserState UserState { get; set; }
    }
}
