using System.Collections.Generic;
using GIShowCam.Utils;

namespace GIShowCam.Info
{
    internal class SessionInfo
    {

        internal static bool
            Debug = false, ShowMessageBoxes = true,
            Audio = false, Playing = false,
            FullVideo = false, FullScreen = false;

        internal static string[] VlcOptions;//, vlcMediaOptions

        internal int DevId = 2;

        internal static string SnapshotDir = "C:\\";
        internal static readonly uint SnapshotStreamNr = 0;

        internal static int ReinitCount = 0;

        internal bool VideoLoop = true;

        internal static readonly string VlcDir32 = @"C:\Program Files (x86)\VideoLAN\VLC",
            VlcDir64 = @"C:\Program Files\VideoLAN\VLC", 
            VlcDir = System.IO.Directory.Exists(VlcDir32) ? VlcDir32 : VlcDir64;
        // new Device("rtsp://10.10.10.202:554/cam/realmonitor?channel=2&subtype=0&unicast=true&proto=Onvif", "admin", "admin")

        private readonly List<Device> _devices = new List<Device>() {
            new Device("http://192.168.0.92/streaming/channels/1/httppreview", "admin", "1qaz@WSX"),
            new Device("rtsp://192.168.0.100:554/0"),// 101 104
            new Device("rtsp://10.10.10.78/axis-media/media.amp", "root", "cavi123,."),
            new Device("http://10.10.10.78/axis-cgi/mjpg/video.cgi", "root", "cavi123,.")
        };

        internal Device Cam;

        internal static CLogger Logger;
        

        internal SessionInfo()
        {

            const string usr = "admin", pass = "admin",
                firstStr = @"rtsp://10.10.10.202:554/cam/realmonitor?channel=",
                lastStr = "&subtype=0";//&unicast=true&proto=Onvif
            for (var i = 1; i < 2; i++)//17
            {
                _devices.Add(new Device(firstStr + i + lastStr, usr, pass));//
            }

            Cam = new Device(_devices[DevId]);// Current Info
            
        }

        internal void UpdateAfterIndexChange(int idx)
        {
            DevId = idx;

            Host = _devices[DevId].Adresa;
            User = _devices[DevId].User;
            Password = _devices[DevId].Parola;
        }

        internal void NewCameraInfo()
        {
            NewCameraInfo(Host, User, Password);
        }
            
        private void NewCameraInfo(string h, string u, string p)
        {
            Cam = new Device(h, u, p);
        }

        internal string[] GetDeviceList()
        {
            int len = _devices.Count;
            string[] retVal = new string[len];
            for (int i = 0; i < len; i++)
                retVal[i] = _devices[i].Adresa;

            return retVal;
        }

        internal string Host
        {
            get
            {
                return Cam.Adresa;
            }

            set
            {
                Cam.Adresa = value;
            }
        }

        internal string User
        {
            get
            {
                return Cam.User;
            }

            set
            {
                Cam.User = value;
            }
        }

        internal string Password
        {
            get
            {
                return Cam.Parola;
            }

            set
            {
                Cam.Parola = value;
            }
        }


    }
}
