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

            opt.ScreenSaverEnabled = false;

            SetDirectory();

            EnableLogConsole();

            AddVlcOptions();            


            Application.Run(new FormMain());


            VlcContext.CloseAll();//+ in VlcCoseEvent
        }

        private static void AddVlcOptions()
        {
            string[] optiuni = new string[] { //--snapshot-format=jpg
                 "--no-fullscreen" // 
               /* ,"--one-instance"  //  Allow only one running instance (default disabled)
                ,"--high-priority" //  Increase the prior-ity of the process (default disabled)    
                ,"--no-video-title"  //hide played media filename on startingto play media.
                //,"--grayscale" //  merge doar daca e enabled in configuration
                //,"--no-video" //  no video
                //,"--image-duration=5" // 
                //,"--ffmpeg-hw" // 
                //,"--video-filter=none" // 
                //,"--live-caching=10000" // 
                //,"--network-caching=1000" //
                //,"--vout none" // ERR => VlcCOntrol
                //,"--disable-debug" // ERR => VlcCOntrol
                //,"--avcodec - hw = vaapi"// ERR => VlcCOntrol <= fara hw-acceleration
                //,"--aspect-ratio=16:9" ,"--fullscreen" ,"--file-caching=3000" // OUT => fullscreen video
                //,"--audio-visual=goom", "--no-fullscreen", "--file-caching=300" // OUT => audio files


                //-------------------  DEFAULT ENABLED <--  to  -->  DISABLED  --------------------------------

                ,"--aout=none" //  main NO audio output ( optional mai e si "--no-audio" )
                ,"--no-sout-audio" //        ^^^  Enable audio stream output (default enabled)
                ,"--no-audio" //             ^^^
                ,"--no-drop-late-frames" //drops frames that are late (arrive to the video output after their intended display date)
                ,"--no-video-deco"  // Window decorations (default enabled)
                ,"--no-skip-frames" // Optional ::> Enables framedropping on MPEG2 stream (default enabled)
                ,"--no-video-title-show" // Display the title of the video on top of the movie. (default enabled)
                ,"--no-spu" // You can completely disable the sub-picture processing. (default enabled)
                ,"--no-sub-autodetect-file" // Autodetect subtitle files (default enabled)
                ,"--no-media-library" // The media library is automatically saved and reloaded each time you start VLC. (default enabled)
                ,"--no-auto-preparse" // Automatically preparse files (default enabled)
                ,"--no-advanced" //  Show advanced options (default enabled)
                ,"--no-interact" // Interface interaction (default enabled) VlcControl are deja Enabled = false
                ,"--no-stats"  //    Collect statistics (default enabled)
                ,"--no-full-help" //  Exhaustive help for VLC and its modules (default enabled)
                ,"--no-playlist-autostart" // playlist auto start (default enabled)
                ,"--no-snapshot-preview"
                ,"--quiet" // deactivates all console messages
                 */
                //,"--no-plugins-cache" // Use a plugins cache which will greatly improve the startup time of VLC. (default enabled)
                //,"--no-ffmpeg-hurry-up" // partially decode or skip frame(s) when there is note enough time
                 
                //,"--vout-filter=crop"
                //,"--grayscale"
                /*,"--aspect-ratio=16:10"*/
                //,"--croppadd-cropleft 100"


            };

            foreach (string optString in optiuni) opt.AddOption(optString);
            

            //VlcContext.StartupOptions.Options.
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
