namespace PRC.MEDIA.OXE
{
    public class RequestNotication
    {
        public Filter filter { get; set; }
        public string sessionId { get; set; }
        public string version { get; set; }
        public int timeout { get; set; }
        public string webHookUrl { get; set; }
    }
}
