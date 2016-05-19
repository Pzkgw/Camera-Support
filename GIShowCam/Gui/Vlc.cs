﻿using GIShowCam.Info;
using System.Linq;
using System;
using Declarations.Events;
using Implementation;
using Declarations.Players;
using Declarations;
using Declarations.Media;
using System.Windows.Forms;
using GIShowCam.Utils;

//  -- Vlc Options & Events --
namespace GIShowCam.Gui
{
    internal partial class GuiBase
    {

        IMediaPlayerFactory m_factory;
        IDiskPlayer m_player;
        IMedia m_media;

        /// <summary>
        /// vlc events
        /// </summary>
        /// <returns></returns>
        internal void RegisterPlayerEvents(bool on)
        {
            if (on)
            {
                m_player.Events.MediaChanged += new EventHandler<MediaPlayerMediaChanged>(Events_MediaChanged);
                m_player.Events.PlayerPositionChanged += new EventHandler<MediaPlayerPositionChanged>(Events_PlayerPositionChanged);
                m_player.Events.PlayerStopped += new EventHandler(Events_PlayerStopped);
            }
            else
            {
                m_player.Events.MediaChanged -= new EventHandler<MediaPlayerMediaChanged>(Events_MediaChanged);
                m_player.Events.PlayerPositionChanged -= new EventHandler<MediaPlayerPositionChanged>(Events_PlayerPositionChanged);
                m_player.Events.PlayerStopped -= new EventHandler(Events_PlayerStopped);
            }


        }


        private void RegisterMediaEvents(bool on)
        {
            if (on)
            {
                //m_media.Events.DurationChanged += new EventHandler<MediaDurationChange>(Events_DurationChanged);
                //m_media.Events.ParsedChanged += new EventHandler<MediaParseChange>(Events_ParsedChanged);
                m_media.Events.StateChanged += new EventHandler<MediaStateChange>(Events_StateChanged);
            }
            else
            {
                //m_media.Events.DurationChanged -= new EventHandler<MediaDurationChange>(Events_DurationChanged);
                //m_media.Events.ParsedChanged -= new EventHandler<MediaParseChange>(Events_ParsedChanged);
                m_media.Events.StateChanged -= new EventHandler<MediaStateChange>(Events_StateChanged);
            }
        }

        #region events

        void Events_MediaChanged(object sender, MediaPlayerMediaChanged e)
        {
            info.cam.data.MediaChanged = true;
        }

        void Events_PlayerStopped(object sender, EventArgs e)
        {
            //UISync.Execute(() => InitControls());
        }


        /*
                private void InitControls()
                {
                    trackBar1.Value = 0;
                    lblTime.Text = "00:00:00";
                    lblDuration.Text = "00:00:00";
                }*/


        //void Events_StateChanged(object sender, MediaStateChange e)
        //{
        //UISync.Execute(() => label1.Text = e.NewState.ToString());
        //}
        /*
        void Events_DurationChanged(object sender, MediaDurationChange e)
        {
            UISync.Execute(() => lblDuration.Text = TimeSpan.FromMilliseconds(e.NewDuration).ToString().Substring(0, 8));
        }

        void Events_ParsedChanged(object sender, MediaParseChange e)
        {
            Console.WriteLine(e.Parsed);
        }*/

        #endregion events


        private void Data_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Log(e.PropertyName);
            //form.ControlTextUpdate(form.btnPlay, (vlc != null && vlc.IsPlaying) ? "Stop" : "Play");
        }

        private void Events_StateChanged(object sender, MediaStateChange e)
        {
            switch (e.NewState)
            {
                case MediaState.Opening:
                    info.cam.data.IsOpening = true;
                    break;
                case MediaState.Buffering:
                    info.cam.data.IsBuffering = true;
                    break;
                case MediaState.Playing:
                    info.cam.data.IsPlaying = true;
                    break;
                case MediaState.Paused:
                    info.cam.data.IsPaused = true;
                    break;
                case MediaState.Stopped:
                    if (!info.cam.data.IsStopped)
                    {
                        SetBtnsVisibilityOnPlay(false);
                    }
                    info.cam.data.IsStopped = true;
                    break;
                case MediaState.Ended:
                    info.cam.data.IsEnded = true;

                    UISync.Execute(() => TextUpdate(form.lblVlcNotify,
                        " Vlc stopped ... ", false, false, false));

                    UISync.Execute(() => ToggleRunningMedia(false));
                    UISync.Execute(() => ToggleRunningMedia(true));

                    //VlcReinit();
                    break;
                case MediaState.Error:
                    info.cam.data.IsError = true;
                    //VlcReinit();
                    break;
                default:
                    break;
            }

            if (m_player != null)
                SessionInfo.playing = m_player.IsPlaying;
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

*/

        //private void VlcReinit()
        //{
            //UISync.on = false;
            /*
            StopRunningMedia();
            VideoInit(false, false);*/

            //(new System.Threading.Thread(delegate () { VideoInit(false,false,true); })).Start(); 
            //vlc.Dispose();
            //GC.Collect();
       // }

        private void SetBtnsVisibilityOnPlay(bool on)
        {

            if (btnsShowOnPlay != on)
            {
                if (on || (!on && !info.cam.data.IsPlaying))
                    UISync.Execute(() => form.btnPlay.Enabled = on);
                UISync.Execute(() => form.btnSnapshot.Enabled = on);
                UISync.Execute(() => form.btnRecord.Enabled = on);
            }

            btnsShowOnPlay = on;
        }
        /*
        internal static string[] GetVlcOptions()
        {
            return new string[] { "--aspect-ratio=4:3" };
        }*/
        
        internal static string[] GetVlcOptions()
        {
            if (SessionInfo.vlcOptions == null)
            {
                SessionInfo.vlcOptions = new string[] { //--snapshot-format=jpg
                "-I", "dumy", "--ignore-config", "--no-osd", "--disable-screensaver", "--plugin-path=./plugins"
                ,"--no-fullscreen" //
                ,"--one-instance"  //  Allow only one running instance (default disabled)
                ,"--high-priority" //  Increase the prior-ity of the process (default disabled)    
                ,"--no-video-title"  //hide played media filename on starting to play media.
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
                //,"--no-snapshot-preview"
                ,SessionInfo.debug?"--verbose=2":"--quiet" // quiet- deactivates all console messages  
                ,SessionInfo.debug?"--extraintf=logger":null
                ,SessionInfo.audio?"--no-sout-audio":null //        ^^^  Enable audio stream output (default enabled)
                ,SessionInfo.audio?"--aout=none":null //  main NO audio output ( optional mai e si "--no-audio" )
                //,"--no-audio" //             ^^^ ERR error la init cateodata when enabled
            }.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            }


            return SessionInfo.vlcOptions;

            //--- Nvlc Init"-I", "dumy", "--ignore-config", "--no-osd",  "--disable-screensaver", "--plugin-path=./plugins"

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
    

        //private string[] GetVlcMediaOptions()
        //{
            /*
            if (SessionInfo.vlcMediaOptions == null)
            {
                SessionInfo.vlcMediaOptions = new string[] {
                "--no-snapshot-preview" // vlcOpt && !vlcMediaOpt
            }.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            }

            return SessionInfo.vlcMediaOptions;*/

           // return null;
        //}


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

        #region CleanUp

        internal void CleanUp()
        {
            CLogger.on = false;

            ToggleRunningMedia(false);

            m_factory.Dispose();            
            m_factory = null;
        }

        #endregion CleanUp

    }
}
