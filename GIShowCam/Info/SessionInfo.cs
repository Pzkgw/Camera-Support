using System;

namespace GIShowCam.Info
{
    class SessionInfo
    {

        private int devID = 0;

        private Device[] devices = new Device[] {            
            new Device(@"http://192.168.0.92/streaming/channels/2/httppreview", "admin", "1qaz@WSX"),
            new Device("rtsp://10.10.10.78/axis-media/media.amp", "root", "cavi123,."),
            new Device("http://10.10.10.78/axis-cgi/mjpg/video.cgi", "root", "cavi123,."),
            new Device("rtsp://10.10.10.202:554/cam/realmonitor?channel=1&subtype=0&unicast=true&proto=Onvif", "admin", "admin"),
            new Device("rtsp://10.10.10.202:554/cam/realmonitor?channel=2&subtype=0&unicast=true&proto=Onvif", "admin", "admin")
        } ;

        private Device cam;

        public SessionInfo()
        {
            cam = new Device(devices[devID]);// Current Info
        }

        internal void Select(int idx)
        {
            cam = new Device(devices[idx]);
        }

        public string[] GetDeviceList()
        {
            string[] retVal = new string[devices.Length];
            for (int i = 0; i < devices.Length; i++)
                retVal[i] = devices[i].adresa;

            return retVal;
        }

        public string host
        {
            get
            {
                return cam.adresa;
            }

            set
            {
                cam.adresa = value;
            }
        }

        public string user
        {
            get
            {
                return cam.user;
            }

            set
            {
                cam.user = value;
            }
        }

        public string password
        {
            get
            {
                return cam.parola;
            }

            set
            {
                cam.parola = value;
            }
        }

        //http://10.10.10.202/onvif/device_service
        //rtsp://10.10.10.78/axis-media/media.amp
        //_camera = IPCameraFactory.GetCamera("rtsp://10.10.10.78/axis-media/media.amp", "root", "cavi123,.");



        //"c:\2016-4-18-18-4-15.mpeg4"
        // "rtsp://10.10.10.78/axis-media/media.amp";
        //rtsp://10.10.10.202:554/cam/realmonitor?channel=1&subtype=0&unicast=true&proto=Onvif
        //-------------->public static string host = @"http://192.168.0.92/streaming/channels/2/httppreview";
        // OPT: ?channel=1&subtype=0&unicast=true    SAU    ?channel=2&subtype=0&unicast=true&proto=Onvif

        //--rtsp-user=username --rtsp-pwd=password
        //"root" 
        //"admin"
        //-------------->public static string user = ;//-user -username --rtsp-user=



        //"cavi123,."
        //"admin"
        //-------------->public static string pass = "";//-passwd --rtsp-pwd=

        public static string snapshotDir = "C:\\";


        //public static string vlcPlugins = @"C:\Program Files (x86)\VideoLAN\VLC\plugins\",
        //   vlc = @"c:\Program Files (x86)\VideoLAN\VLC\";

    }
}
