﻿using Declarations;
using Declarations.Players;
using GISendLib;
using Implementation;
using System;
using System.Threading;

namespace GIStreamReceive
{
    class MainReceive
    {
        Form1 form;

        private IMediaPlayerFactory _mFactory;
        private IVideoPlayer _mPlayer;

        string[] opt = new[] { //--snapshot-format=jpg
                "-I", "dumy", "--ignore-config", "--no-osd", "--disable-screensaver", "--plugin-path=./plugins"
                ,"--no-fullscreen" //
                //,"--one-instance"  //  Allow only one running instance (default disabled)
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
                ,"--no-snapshot-preview"
                ,"--quiet" // quiet- deactivates all console messages  
                ,"--no-sout-audio" //        ^^^  Enable audio stream output (default enabled)
                ,"--aout=none" //  main NO audio output ( optional mai e si "--no-audio" )

        };

        Class1 gs;

        public MainReceive(Form1 fork)
        {

            gs = new Class1(); // inainte de MainReceive::_mFactory->Init()
            //Thread.Sleep(100);
            gs.GetBase().StateChanged += MainReceive_StateChanged;

            form = fork;

            _mFactory = new MediaPlayerFactory(opt,//new string[] { },
                @"C:\Program Files (x86)\VideoLAN\VLC", false, new CLogger());

            _mPlayer = _mFactory.CreatePlayer<IVideoPlayer>();
            _mPlayer.WindowHandle = form.panel1.Handle;
            _mPlayer.Open(gs.GetBase().InputMedia);
            _mPlayer.Play();

            gs.GetBase().Player.Events.PlayerPositionChanged += Events_PlayerPositionChanged;
            

        }

        private void MainReceive_StateChanged(object sender, Declarations.Events.MediaStateChange e)
        {
            try
            {
                switch (e.NewState)
                {
                    case MediaState.Opening:
                        break;
                    case MediaState.Buffering:
                        break;
                    case MediaState.Playing:
                        
                        break;
                    case MediaState.Paused:
                    case MediaState.Stopped:
                    case MediaState.Ended:
                    case MediaState.Error:
                        _mPlayer.Stop();
                        break;
                    case MediaState.NothingSpecial:
                        break;
                }

                //CLogger.VideoOnPlay = _info.Cam.Data.IsPlaying;
            }
            finally
            {

            }
        }

        


        private void Events_PlayerPositionChanged(object sender, Declarations.Events.MediaPlayerPositionChanged e)
        {
            form.BeginInvoke((Action)(() => form.label1.Text = ("PendingFramesCount = " + gs.GetBase().InputMedia.PendingFramesCount.ToString())));
        }
    }
}
