using System.Collections.Generic;

namespace PRC.MEDIA.OXE
{
    public class SessionResponse
    {
        public bool admin { get; set; }
        public int timeToLive { get; set; }
        public string publicBaseUrl { get; set; }
        public string privateBaseUrl { get; set; }
        public List<Service> services { get; set; }
    }
}
