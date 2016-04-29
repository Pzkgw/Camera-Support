using GIShowCam.Info;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Vlc.DotNet.Forms;

namespace GIShowCam.Gui
{
    internal partial class GuiBase
    {
        private VlcControl vlc;

        //private static VlcStartupOptions opt;


        private void InitVlc()
        {
            //opt = VlcContext.StartupOptions;

            //opt.ScreenSaverEnabled = false;

            //SetDirectory();

            //if (SessionInfo.debug) EnableLogConsole();


            //VlcContext.StartupOptions.AddOption("--width=" + panelVlc.Width);
            //VlcContext.StartupOptions.AddOption("--height=" + panelVlc.Height);
            //VlcContext.StartupOptions.AddOption("--aspect-ratio=1:9");
            //VlcContext.StartupOptions.AddOption("--autocrop");--crop-geometry "180 x 120 + 0 + 0"
            //VlcContext.StartupOptions.AddOption("--crop-geometry \"" + panelVlc.Width + "x" + panelVlc.Height + " + 0 + 0\"");--aspect-ratio=16:9

            //vlc http://admin:1qaz@WSX@192.168.0.92/streaming/channels/2/httppreview --aspect-ratio=16:9


            vlc = new VlcControl();
            vlc.Name = "vlc";
            vlc.TabStop = false;
            vlc.Enabled = false;
            vlc.ImeMode = ImeMode.NoControl;
            vlc.Dock = DockStyle.Fill;
            vlc.BackColor = Color.Empty;
            //vlc.Rate = 0.0f;
            //vlc.Location = new Point(0,0);
            //vlc.Size = new Size(panelVlc.Width, panelVlc.Height);
            //vlc.Width = panelVlc.Width;
            //vlc.Height = panelVlc.Height;
            //vlc.SetBounds(0, 0, panelVlc.Width, panelVlc.Height);

            setVlcLibLocation();
            AddVlcOptions();
            vlc.EndInit();

        }


        private void AddVlcOptions()
        {
            string[] optiuni = new string[] { //--snapshot-format=jpg
                 "--no-fullscreen" //
                ,"--one-instance"  //  Allow only one running instance (default disabled)
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
                //,"--no-audio" //             ^^^ ERR error la init cateodata when enabled
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
                ,SessionInfo.debug?"":"--no-stats" //    Collect statistics (default enabled)
                ,"--no-full-help" //  Exhaustive help for VLC and its modules (default enabled)
                ,"--no-playlist-autostart" // playlist auto start (default enabled)
                ,"--no-snapshot-preview"
                ,SessionInfo.debug?"":"--quiet" // deactivates all console messages
                // 

                //,"--no-plugins-cache" // Use a plugins cache which will greatly improve the startup time of VLC. (default enabled)
                //,"--no-ffmpeg-hurry-up" // partially decode or skip frame(s) when there is note enough time
                 
                //,"--vout-filter=crop"
                //,"--grayscale"
                //,"--aspect-ratio=16:10"
                //,"--croppadd-cropleft 100"


            };

            vlc.VlcMediaplayerOptions = optiuni;
            //foreach (string optString in optiuni) opt.AddOption(optString);


            //VlcContext.StartupOptions.Options.
        }


        private void setVlcLibLocation()
        {
            //vlc.VlcLibDirectoryNeeded += Vlc_VlcLibDirectoryNeeded;

            string aP;
            if (Environment.Is64BitOperatingSystem)
                aP = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "VideoLAN\\VLC");
            else
                aP = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "VideoLAN\\VLC");

            /*else if (!File.Exists(Path.Combine(aP, "libvlc.dll"))
                           {
                           Using fbdDialog As New FolderBrowserDialog()
                           fbdDialog.Description = "Select VLC Path"
                           fbdDialog.SelectedPath = Path.Combine(aP, "VideoLAN\VLC")

                           If fbdDialog.ShowDialog() = DialogResult.OK Then
                           e.VlcLibDirectory = New DirectoryInfo(fbdDialog.SelectedPath)
                       }

            e.VlcLibDirectory = new DirectoryInfo(aP);*/

            vlc.VlcLibDirectory = new DirectoryInfo(aP);

        }


        protected void VideoPlayInit()
        {
            if (vlc != null)
            {

                if (vlc.IsPlaying)
                {
                    form.Restart();
                }

                if (vlc.GetCurrentMedia() != null)
                {
                    vlc.GetCurrentMedia().Dispose();
                    vlc.Stop();
                }

                if (info.host.Count(s => s == '.') > 2)
                {
                    string path = info.host;

                    if (!string.IsNullOrEmpty(info.user) && !string.IsNullOrEmpty(info.password) && ((path[5] == '/') || (path[6] == '/')))// http:// sau rtsp://
                    {
                        path = path.Insert(7, (info.user + ":" + info.password + "@"));
                    }

                    //vlc rtsp://10.10.10.78/axis-media/media.amp --rtsp-user=root --rtsp-pwd=cavi123,.
                    //LocationMedia media = new LocationMedia(path);
                    //media.AddOption("no-snapshot-preview");
                    //media.AddOption("-vvv");//optional : "Verbose verbose verbose". Verbose output
                    //media.AddOption("–-aspect-ratio=4:3");
                    //media.AddOption("--grayscale");



                    vlc.SetMedia(path);
                }
                else
                {
                    vlc.SetMedia(info.host);
                }

            }
        }

        /*
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
        }*/


    }
}
