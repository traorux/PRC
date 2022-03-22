using System.Collections.Generic;

namespace PRC.MEDIA.OXE
{
    public class ApiTestResponse
    {
        public ServerInfo serverInfo { get; set; }
        public List<Version> versions { get; set; }
    }
}
