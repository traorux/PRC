namespace PRC.MEDIA.OXE
{
    public class CallResponse
    {
        public string httpStatus { get; set; }
        public int code { get; set; }
        public string helpMessage { get; set; }
        public string type { get; set; }
        public string innerMessage { get; set; }
        public bool canRetry { get; set; }
    }
}
