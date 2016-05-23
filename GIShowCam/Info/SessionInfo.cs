using System.Collections.Generic;

namespace GIShowCam.Info
{
    class SessionInfo
    {
 
        internal static bool
            debug = false, showMessageBoxes = true,
            audio = false, fullVideo = false, playing = false;

        internal static string[] vlcOptions;//, vlcMediaOptions
        internal static string snapshotDir = "C:\\";

        internal static int reinitCount = 0;

        internal bool videoLoop = true;
        internal int devID = 4;

        internal static readonly string vlcDir32 = @"C:\Program Files (x86)\VideoLAN\VLC",
            vlcDir64 = @"C:\Program Files\VideoLAN\VLC", 
            vlcDir = System.IO.Directory.Exists(SessionInfo.vlcDir32) ? SessionInfo.vlcDir32 : SessionInfo.vlcDir64;
        // new Device("rtsp://10.10.10.202:554/cam/realmonitor?channel=2&subtype=0&unicast=true&proto=Onvif", "admin", "admin")

        private List<Device> devices = new List<Device>() {
            new Device("http://192.168.0.92/streaming/channels/1/httppreview", "admin", "1qaz@WSX"),
            new Device("rtsp://192.168.0.100:554/0"),// 101 104
            new Device("rtsp://10.10.10.78/axis-media/media.amp", "root", "cavi123,."),
            new Device("http://10.10.10.78/axis-cgi/mjpg/video.cgi", "root", "cavi123,.")
        };

        internal Device cam;

        internal static CLogger logger;

        internal SessionInfo()
        {

            const string usr = "admin", pass = "admin",
                firstStr = @"rtsp://10.10.10.202:554/cam/realmonitor?channel=",
                lastStr = "&subtype=0";//&unicast=true&proto=Onvif
            for (int i = 1; i < 2; i++)//17
            {
                devices.Add(new Device(firstStr + i + lastStr, usr, pass));//
            }

            cam = new Device(devices[devID]);// Current Info
            
        }

        internal void UpdateAfterIndexChange(int idx)
        {
            devID = idx;

            host = devices[devID].adresa;
            user = devices[devID].user;
            password = devices[devID].parola;
        }

        internal void NewCameraInfo()
        {
            NewCameraInfo(host, user, password);
        }
            
        private void NewCameraInfo(string h, string u, string p)
        {
            cam = new Device(h, u, p);
        }

        internal string[] GetDeviceList()
        {
            int len = devices.Count;
            string[] retVal = new string[len];
            for (int i = 0; i < len; i++)
                retVal[i] = devices[i].adresa;

            return retVal;
        }

        internal string host
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

        internal string user
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

        internal string password
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
