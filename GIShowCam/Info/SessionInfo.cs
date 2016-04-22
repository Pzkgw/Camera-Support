namespace GIShowCam.Info
{
    class SessionInfo
    {


        //http://10.10.10.202/onvif/device_service
        //rtsp://10.10.10.78/axis-media/media.amp
        //_camera = IPCameraFactory.GetCamera("rtsp://10.10.10.78/axis-media/media.amp", "root", "cavi123,.");



        //"c:\2016-4-18-18-4-15.mpeg4"
        // "rtsp://10.10.10.78/axis-media/media.amp";
        //rtsp://10.10.10.202:554/cam/realmonitor?channel=1&subtype=0&unicast=true&proto=Onvif
        public static string host = "c:\\2016-4-18-18-4-15.mpeg4";//@"rtsp://10.10.10.78/axis-media/media.amp";
        // OPT: ?channel=1&subtype=0&unicast=true    SAU    ?channel=2&subtype=0&unicast=true&proto=Onvif

        //--rtsp-user=username --rtsp-pwd=password
        //"root" 
        //"admin"
        public static string user = "root";//-user -username --rtsp-user=



        //"cavi123,."
        //"admin"
        public static string pass = "cavi123,.";//-passwd --rtsp-pwd=




        public static string vlcPlugins = @"C:\Program Files (x86)\VideoLAN\VLC\plugins\",
            vlc = @"c:\Program Files (x86)\VideoLAN\VLC\";

    }
}
