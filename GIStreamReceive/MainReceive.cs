using Declarations;
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
            @"rtsp://admin:admin@10.10.10.202:554/cam/realmonitor?channel=1&subtype=0",
            @"rtsp://root:cavi123,.@10.10.10.78/axis-media/media.amp"
        };

        int si = 1;

        public MainReceive(Form1 fork)
        {
            gs = new Class1(); // inainte de MainReceive::_mFactory->Init()

            gs.GetBase().Player.Events.PlayerPositionChanged += Events_PlayerPositionChanged;


            //gs.GetBase().StateChanged += MainReceive_StateChanged;

            //++si;
            //gs.GetBase().TogglePlay(true, s[si]);

            form = fork;
            //g = form.panel1.CreateGraphics();

            _mFactory = new MediaPlayerFactory(opt,//new string[] { },
                @"C:\Program Files (x86)\VideoLAN\VLC", true, new CLogger());

            _mPlayer = _mFactory.CreatePlayer<IVideoPlayer>();
            _mPlayer.WindowHandle = form.panel1.Handle;

            PlayStart(s[si]);
            //ToggleMedia(false, null);
            //ToggleMedia(true, s[si]);

            // gs.GetBase().Player.CurrentMedia.Events.StateChanged += Events_StateChanged;
            //_mPlayer.CurrentMedia.Events.StateChanged += Events_StateChanged1;

        }

        private void PlayStart(string adr)
        {

            gs.GetBase().PlayStart(adr);
            _mPlayer.Open(gs.GetBase().InputMedia);

        }

        private void PlayStop()
        {
            gs.GetBase().PlayStop();
            _mPlayer.Stop();
        }

        private void Events_StateChanged1(object sender, Declarations.Events.MediaStateChange e)
        {

        }

        private void Events_StateChanged(object sender, Declarations.Events.MediaStateChange e)
        {
            //gs.GetBase().PlayStart(s[si]);
        }

        //Graphics g;

        //private void OnNewFrameCallback(System.Drawing.Bitmap frame)        {
        //g.DrawImage(frame, Point.Empty);        }

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
                        //_mPlayer.Play();
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
            if (startToPlay)
            {
                form.BeginInvoke((Action)(() => form.label1.Text = ("PendingFramesCount = " + gs.GetBase().InputMedia.PendingFramesCount.ToString())));
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
