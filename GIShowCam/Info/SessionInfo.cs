﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIShowCam.Info
{
    class SessionInfo
    {

        //"c:\\2016-4-18-18-4-15.mpeg4"
        // "rtsp://10.10.10.78/axis-media/media.amp";
        //rtsp://10.10.10.202:554/cam/realmonitor?channel=1&subtype=0&unicast=true&proto=Onvif
        public static string host = "rtsp://10.10.10.202:554/cam/realmonitor?channel=1&subtype=0&unicast=true&proto=Onvif";



        //"root"
        public static string user = "admin";



        //"cavi123,."
        public static string pass = "admin";




        public static string vlcPlugins = @"C:\Program Files (x86)\VideoLAN\VLC\plugins\",
            vlc = @"c:\Program Files (x86)\VideoLAN\VLC\";

    }
}
