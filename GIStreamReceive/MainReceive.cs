using Declarations;
using Declarations.Events;
using Declarations.Players;
using GISendLib;
using Implementation;
using System;
using System.Drawing;
using System.Threading;

namespace GIStreamReceive
{
    class MainReceive
    {
        Form1 form;

        private IMediaPlayerFactory _mFactory;
        private IVideoPlayer _mPlayer;

        string[] opt = new string[] { };

        Class1 gs;

        bool startToPlay;

        string[] s = new[] {
            @"rtsp://root:cavi123,.@10.10.10.78/axis-media/media.amp",/*
            @"rtsp://admin:admin@10.10.10.202:554/cam/realmonitor?channel=1&subtype=0",
            @"rtsp://root:cavi1234@10.10.10.101:8000",
            @"http://admin:1qaz@WSX@10.10.10.208",
            @"http://admin:1qaz@WSX@192.168.0.92/streaming/channels/1/httppreview",
            @"rtsp://192.168.0.100:554/0",*/
            @"http://root:cavi123,.@10.10.10.78/axis-cgi/mjpg/video.cgi"
        };

        int si = 0;

        public MainReceive(Form1 fork)
        {
            gs = new Class1(); // inainte de MainReceive::_mFactory->Init()

            


            //gs.GetBase().StateChanged += MainReceive_StateChanged;

            //++si;
            //gs.GetBase().TogglePlay(true, s[si]);

            form = fork;
            //g = form.panel1.CreateGraphics();

            _mFactory = new MediaPlayerFactory(opt,//new string[] { },
                @"C:\Program Files (x86)\VideoLAN\VLC", true, new CLogger());

            _mPlayer = _mFactory.CreatePlayer<IVideoPlayer>();
            _mPlayer.WindowHandle = form.panel1.Handle;

            // true: 00, 01
            // false:11, 10
            PlayStart(s[1]);
            //Thread.Sleep(5000);
            PlayStop(); // --> ev # s

            PlayStart(s[1]);


            //_mPlayer.CurrentMedia.Events.StateChanged += Events_StateChanged1;

        }

        private void PlayStart(string adr)
        {

            gs.GetBase().PlayStart(adr);
            _mPlayer.Open(gs.GetBase().InputMedia);

            gs.GetBase().Player.CurrentMedia.Events.StateChanged += MainReceive_StateChanged;
            gs.GetBase().Player.Events.PlayerPositionChanged += Events_PlayerPositionChanged;

        }

        private void PlayStop()
        {
            //_mFactory.
            gs.GetBase().Player.CurrentMedia.Events.StateChanged -= MainReceive_StateChanged;
            gs.GetBase().Player.Events.PlayerPositionChanged -= Events_PlayerPositionChanged;
            _mPlayer.Stop();
            gs.GetBase().PlayStop();
        }

        //Graphics g;

        //private void OnNewFrameCallback(System.Drawing.Bitmap frame)        {
        //g.DrawImage(frame, Point.Empty);        }

        private void MainReceive_StateChanged(object sender, MediaStateChange e)
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
                        //_mPlayer.Play();
                        break;
                    case MediaState.Paused:
                    case MediaState.Stopped:
                    case MediaState.Ended:
                    case MediaState.Error:
                        //_mPlayer.Stop();
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

        private void Events_PlayerPositionChanged(object sender, MediaPlayerPositionChanged e)
        {
            if (startToPlay)
            {
                try
                {
                    //form.BeginInvoke((Action)(() => form.label1.Text = ("PendingFramesCount = " + gs.GetBase().InputMedia.PendingFramesCount.ToString())));
                }
                catch (Exception ex) { }
            }
            else
            {
                _mPlayer.Play();
                startToPlay = true;
                //form.BeginInvoke((Action)(() => form.label1.Text = ("Inainte de pendingFrames ... ")));
            }
        }
    }
}
