using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Core;

namespace GIShowCam
{
    static class ProgramMain
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            // Set libvlc.dll and libvlccore.dll directory path
            VlcContext.LibVlcDllsPath = CommonStrings.LIBVLC_DLLS_PATH_DEFAULT_VALUE_AMD64;

            // Set the vlc plugins directory path
            VlcContext.LibVlcPluginsPath = CommonStrings.PLUGINS_PATH_DEFAULT_VALUE_AMD64;

            // Ignore the VLC configuration file
            VlcContext.StartupOptions.IgnoreConfig = true;

            // Enable file based logging
            VlcContext.StartupOptions.LogOptions.LogInFile = true;

            // Shows the VLC log console (in addition to the applications window)
            VlcContext.StartupOptions.LogOptions.ShowLoggerConsole = true;

            // Set the log level for the VLC instance
            VlcContext.StartupOptions.LogOptions.Verbosity = VlcLogVerbosities.Debug;

            VlcContext.StartupOptions.AddOption("--image-duration=5");
            VlcContext.StartupOptions.AddOption("--ffmpeg-hw");
            //VlcContext.StartupOptions.AddOption("--video-filter=none");


            Application.Run(new FormMain());


            VlcContext.CloseAll();
        }
    }
}
