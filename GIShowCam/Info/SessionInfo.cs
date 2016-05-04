using System.Collections.Generic;

namespace GIShowCam.Info
{
    class SessionInfo
    {
        internal static bool debug = true, log = true, audio = false, fullVideo = false;
        internal static string snapshotDir = "C:\\";

        internal bool videoLoop = true;
        internal int devID = 6;

        //public static string vlcPlugins = @"C:\Program Files (x86)\VideoLAN\VLC\plugins\",
        //   vlc = @"c:\Program Files (x86)\VideoLAN\VLC\";
        // new Device("rtsp://10.10.10.202:554/cam/realmonitor?channel=2&subtype=0&unicast=true&proto=Onvif", "admin", "admin")

        private List<Device> devices = new List<Device>() {
            new Device("http://192.168.0.92/streaming/channels/2/httppreview", "admin", "1qaz@WSX"),
            new Device("rtsp://192.168.0.101:554/0"),
            new Device("rtsp://192.168.0.100:554/0"),
            new Device("rtsp://192.168.0.104:554/0"),
            new Device("rtsp://10.10.10.78/axis-media/media.amp", "root", "cavi123,."),
            new Device("http://10.10.10.78/axis-cgi/mjpg/video.cgi", "root", "cavi123,.")
        };

        internal Device cam;

        internal SessionInfo()
        {


            const string usr = "admin", pass = "admin",
                firstStr = @"rtsp://10.10.10.202:554/cam/realmonitor?channel=",
                lastStr = "&subtype=0";//&unicast=true&proto=Onvif
            for (int i = 1; i < 17; i++)
            {
                devices.Add(new Device(firstStr + i + lastStr, usr, pass));//
            }

            cam = new Device(devices[devID]);// Current Info
        }

        internal void SelectCamera(int idx)
        {
            devID = idx;
            SelectCamera(devices[idx].adresa, devices[idx].user, devices[idx].parola);
        }

        internal void SelectCamera()
        {
            SelectCamera(host, user, password);
        }
            
        private void SelectCamera(string h, string u, string p)
        {
            cam = new Device(host, user, password);
        }

        public string[] GetDeviceList()
        {
            int len = devices.Count;
            string[] retVal = new string[len];
            for (int i = 0; i < len; i++)
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


    }
}
