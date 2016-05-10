using GIShowCam.Info;
using System.Linq;
using System.Windows.Forms;
using System;
using Declarations.Events;

//  -- Vlc Options & Events --
namespace GIShowCam.Gui
{
    internal partial class GuiBase
    {
        private bool btnsShowOnPlay; 

        //private Vlc.DotNet.Core.Interops.Signatures.MediaStates oldState;

        /// <summary>
        /// vlc events
        /// </summary>
        /// <returns></returns>
        private void AddVlcEvents()
        {
            /*
            vlc.Buffering += Vlc_Buffering;
            vlc.EncounteredError += Vlc_EncounteredError;            
            vlc.PositionChanged += Vlc_PositionChanged;
            vlc.MediaChanged += Vlc_MediaChanged;*/
        }

        #region events

        void Events_PlayerStopped(object sender, EventArgs e)
        {
            UISync.Execute(() => InitControls());
        }

        void Events_MediaEnded(object sender, EventArgs e)
        {
            UISync.Execute(() => InitControls());
        }

        private void InitControls()
        {/*
            trackBar1.Value = 0;
            lblTime.Text = "00:00:00";
            lblDuration.Text = "00:00:00";*/
        }

        void Events_TimeChanged(object sender, MediaPlayerTimeChanged e)
        {
            //UISync.Execute(() => lblTime.Text = TimeSpan.FromMilliseconds(e.NewTime).ToString().Substring(0, 8));
        }

        void Events_PlayerPositionChanged(object sender, MediaPlayerPositionChanged e)
        {
            //UISync.Execute(() => trackBar1.Value = (int)(e.NewPosition * 100));
        }

        void Events_StateChanged(object sender, MediaStateChange e)
        {
            //UISync.Execute(() => label1.Text = e.NewState.ToString());
        }

        void Events_DurationChanged(object sender, MediaDurationChange e)
        {
            //UISync.Execute(() => lblDuration.Text = TimeSpan.FromMilliseconds(e.NewDuration).ToString().Substring(0, 8));
        }

        void Events_ParsedChanged(object sender, MediaParseChange e)
        {
            Console.WriteLine(e.Parsed);
        }

        #endregion events


        private void Data_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            form.Log(e.PropertyName);
            //form.ControlTextUpdate(form.btnPlay, (vlc != null && vlc.IsPlaying) ? "Stop" : "Play");
        }
        /*

        private void Vlc_EncounteredError(object sender, VlcMediaPlayerEncounteredErrorEventArgs e)
        {
            //if (SessionInfo.showMessageBoxes) MessageBox.Show(e.ToString());
            form.Log(e.ToString());
        }

        private void Vlc_Buffering(object sender, Vlc.DotNet.Core.VlcMediaPlayerBufferingEventArgs e)
        {
            form.Test(e.NewCache.ToString());

            if (!info.cam.data.IsBuffering && !(e.NewCache < 100)) info.cam.data.IsBuffering = true;
        }

        private void GuiBase_StateChanged(object sender, VlcMediaStateChangedEventArgs e)
        {
            switch (vlc.State)
            {
                case Vlc.DotNet.Core.Interops.Signatures.MediaStates.Opening:
                    info.cam.data.IsOpening = true;
                    break;
                case Vlc.DotNet.Core.Interops.Signatures.MediaStates.Buffering:
                    info.cam.data.IsBuffering = true;
                    break;
                case Vlc.DotNet.Core.Interops.Signatures.MediaStates.Playing:
                    info.cam.data.IsPlaying = true;
                    break;
                case Vlc.DotNet.Core.Interops.Signatures.MediaStates.Paused:
                    info.cam.data.IsPaused = true;
                    break;
                case Vlc.DotNet.Core.Interops.Signatures.MediaStates.Stopped:
                    if (!info.cam.data.IsStopped)
                    {
                        SetBtnsVisibilityOnPlay(false);
                    }
                    info.cam.data.IsStopped = true;
                    break;
                case Vlc.DotNet.Core.Interops.Signatures.MediaStates.Ended:
                    info.cam.data.IsEnded = true;
                    VlcReinit();
                    break;
                case Vlc.DotNet.Core.Interops.Signatures.MediaStates.Error:
                    info.cam.data.IsError = true;
                    VlcReinit();
                    break;
                default:
                    break;
            }
        }*/

        private void VlcReinit()
        {/*
            form.isOn = false;
            form.AddVlc(null);
            vlc.Dispose();
            vlc = null;

            form.WaitForVlc(1040);
            BtnDevConnect_Click(null, null);
            */
            //(new System.Threading.Thread(delegate () { VideoInit(false,false,true); })).Start(); 
            //vlc.Dispose();
            //GC.Collect();
        }

        private void SetBtnsVisibilityOnPlay(bool on)
        {
            if (btnsShowOnPlay != on)
            {
                if (on || (!on && !info.cam.data.IsPlaying)) form.ControlShow(form.btnPlay, on);
                form.ControlShow(form.btnSnapshot, on);
                form.ControlShow(form.btnRecord, on);
            }

            btnsShowOnPlay = on;
        }

        private string[] GetVlcOptions()
        {
            if (SessionInfo.vlcOptions == null)
            {
                SessionInfo.vlcOptions = new string[] { //--snapshot-format=jpg
                 "--no-fullscreen" //
                //,"--one-instance"  //  Allow only one running instance (default disabled)
                ,"--high-priority" //  Increase the prior-ity of the process (default disabled)    
                ,"--no-video-title"  //hide played media filename on startingto play media.
                //,"--rtsp-tcp"
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
                ,SessionInfo.debug?"--verbose=2":"--quiet" // quiet- deactivates all console messages  
                ,SessionInfo.debug?"--extraintf=logger":null
                ,SessionInfo.audio?"--no-sout-audio":null //        ^^^  Enable audio stream output (default enabled)
                ,SessionInfo.audio?"--aout=none":null //  main NO audio output ( optional mai e si "--no-audio" )
                //,"--no-audio" //             ^^^ ERR error la init cateodata when enabled
            }.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            }


            return SessionInfo.vlcOptions;


            //  ---  Alte incercari:
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

            //,"--no-plugins-cache" // Use a plugins cache which will greatly improve the startup time of VLC. (default enabled)
            //,"--no-ffmpeg-hurry-up" // partially decode or skip frame(s) when there is note enough time
            //,"--no-stats" //  NOT, folosita pt SendImagesCount  Collect statistics (default enabled)

            //,"--vout-filter=crop"
            //,"--grayscale"
            //,"--aspect-ratio=16:10"
            //,"--croppadd-cropleft 100"
        }


        private string GetVlcLibLocation()
        {
            /*
            string aP;
            if (Environment.Is64BitOperatingSystem)
                aP = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "VideoLAN\\VLC");
            else
                aP = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "VideoLAN\\VLC");
                */
            /*else if (!File.Exists(Path.Combine(aP, "libvlc.dll"))
                           {
                           Using fbdDialog As New FolderBrowserDialog()
                           fbdDialog.Description = "Select VLC Path"
                           fbdDialog.SelectedPath = Path.Combine(aP, "VideoLAN\VLC")

                           If fbdDialog.ShowDialog() = DialogResult.OK Then
                           e.VlcLibDirectory = New DirectoryInfo(fbdDialog.SelectedPath)
                       }

            e.VlcLibDirectory = new DirectoryInfo(aP);*/

            return "c:\\Program Files (x86)\\VideoLAN\\VLC";//aP;
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


        #region CleanUp

        internal void CleanUp()
        {
            form.isOn = false;// avoid event send
            //if (vlc.IsPlaying) vlc.Stop(true);
            //if (vlc.Media != null) vlc.Media.Dispose();
            //if (vlc != null) vlc.Dispose();

            //VlcContext.CloseAll();
            //vlc.CleanUp();
        }

        #endregion CleanUp

    }
}
