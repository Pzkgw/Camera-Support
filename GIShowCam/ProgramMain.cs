using System;
using System.Windows.Forms;
using Vlc.DotNet.Core;

namespace GIShowCam
{
    static class ProgramMain
    {

        private static VlcStartupOptions opt;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            opt = VlcContext.StartupOptions;

            SetDirectory();

            EnableLogConsole();

            AddVlcOptions();            


            Application.Run(new FormMain());


            VlcContext.CloseAll();//Prezenta si in VlcCoseEvent
        }

        private static void AddVlcOptions()
        {

            
            //opt.AddOption("--image-duration=5");
            //opt.AddOption("--ffmpeg-hw");
            opt.AddOption("--no-skip-frames");
            opt.AddOption("--high-priority");
            //opt.AddOption("--video-filter=none");
            //opt.AddOption("--live-caching=10000");
            //opt.AddOption("--network-caching=1000");


            //opt.AddOption("--disable-debug");// NU merge
            //opt.AddOption("--avcodec - hw = vaapi");// outputs ERROR in VlcCOntrol daca nu e hw-acceleration


            VlcContext.Initialize();
        }


        private static void SetDirectory()
        {
            // Set libvlc.dll and libvlccore.dll directory path
            VlcContext.LibVlcDllsPath = CommonStrings.LIBVLC_DLLS_PATH_DEFAULT_VALUE_AMD64;

            // Set the vlc plugins directory path
            VlcContext.LibVlcPluginsPath = CommonStrings.PLUGINS_PATH_DEFAULT_VALUE_AMD64;

            // Ignore the VLC configuration file
            opt.IgnoreConfig = true;
        }


        private static void EnableLogConsole()
        {
            // Enable file based logging
            opt.LogOptions.LogInFile = true;

            // Shows the VLC log console (in addition to the applications window)
            opt.LogOptions.ShowLoggerConsole = true;

            // Set the log level for the VLC instance
            opt.LogOptions.Verbosity = VlcLogVerbosities.Debug;
        }
    }
}
