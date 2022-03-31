using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Media.Call.Types.Device
{
    public class DeviceState
    {
        public string DeviceId { get; init; }
        public OperationalState State { get; init; }
    }
}
