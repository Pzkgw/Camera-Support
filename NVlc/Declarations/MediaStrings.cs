namespace Declarations
{
    /// <summary>
    /// String values used to identify media types.
    /// </summary>
    public class MediaStrings
    {
        public const string DVD = @"dvd://";
        public const string VCD = @"vcd://";
        public const string CDDA = @"cdda://";
        public const string BLURAY = @"bluray://";

        public const string RTP = @"rtp://";
        public const string RTSP = @"rtsp://";
        public const string HTTP = @"http://";
        public const string UDP = @"udp://";
        public const string MMS = @"mms://";

        public const string DSHOW = @"dshow://";
        public const string SCREEN = @"screen://";

        /// <summary>
        /// Fake access module. Should be used with IVideoInputMedia objects.
        /// </summary>
        public const string FAKE = @"fake://";

        /// <summary>
        /// imem access module. Should be used with IMemoryInputMedia objects
        /// </summary>
        public const string IMEM = @"imem://";
    }
}
