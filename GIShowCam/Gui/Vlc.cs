using GIShowCam.Info;
using GIShowCam.Vlc_override;
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
        private GIVlcControl vlc;
        //private Vlc.DotNet.Core.Interops.Signatures.MediaStates oldState;


        private void InitVlcStart()
        {
            //opt = VlcContext.StartupOptions;

            //opt.ScreenSaverEnabled = false;

            //SetDirectory();

            //if (SessionInfo.debug) EnableLogConsole();

            vlc = new GIVlcControl();
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
        }

        private void InitVlcEnd()
        {
            vlc.VlcLibDirectory = new DirectoryInfo(GetVlcLibLocation());
            vlc.VlcMediaplayerOptions = GetVlcOptions();
            vlc.EndInit();
        }

        private void Vlc_Buffering(object sender, Vlc.DotNet.Core.VlcMediaPlayerBufferingEventArgs e)
        {
            form.Test(e.NewCache.ToString());

            if (!info.cam.data.IsBuffering && !(e.NewCache < 100)) info.cam.data.IsBuffering = true;
        }

        private string[] GetVlcOptions()
        {
            return new string[] { //--snapshot-format=jpg
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
                ,"--no-full-help" //  Exhaustive help for VLC and its modules (default enabled)
                ,"--no-playlist-autostart" // playlist auto start (default enabled)                
                ,"--no-snapshot-preview"
                //,"--no-plugins-cache" // Use a plugins cache which will greatly improve the startup time of VLC. (default enabled)
                //,"--no-ffmpeg-hurry-up" // partially decode or skip frame(s) when there is note enough time
                //,"--no-stats" //  NOT, folosita pt SendImagesCount  Collect statistics (default enabled)
                 
                //,"--vout-filter=crop"
                //,"--grayscale"
                //,"--aspect-ratio=16:10"
                //,"--croppadd-cropleft 100"
                ,SessionInfo.debug?"--extraintf=logger":"" 
                ,SessionInfo.debug?"--verbose=2":"--quiet" // quiet- deactivates all console messages
                ,SessionInfo.audio?"--aout=none":"" //  main NO audio output ( optional mai e si "--no-audio" )
                ,SessionInfo.audio?"--no-sout-audio":"" //        ^^^  Enable audio stream output (default enabled)
                //,"--no-audio" //             ^^^ ERR error la init cateodata when enabled
            };
            //foreach (string optString in optiuni) opt.AddOption(optString);
        }


        private string GetVlcLibLocation()
        {
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

            return aP;
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
