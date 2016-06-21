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

        public MainReceive(Form1 fork)
        {

            gs = new Class1(); // inainte de MainReceive::_mFactory->Init()
            //Thread.Sleep(100);
            //gs.GetBase().StateChanged += MainReceive_StateChanged;

            form = fork;

            _mFactory = new MediaPlayerFactory(opt,//new string[] { },
                @"C:\Program Files (x86)\VideoLAN\VLC", false, new CLogger());

            _mPlayer = _mFactory.CreatePlayer<IVideoPlayer>();
            _mPlayer.WindowHandle = form.panel1.Handle;          
            //_mPlayer.CustomRenderer.SetCallback(OnNewFrameCallback);
            _mPlayer.Open(gs.GetBase().InputMedia);

            

            gs.GetBase().Player.Events.PlayerPositionChanged += Events_PlayerPositionChanged;

            g = form.panel1.CreateGraphics();



        }

        Graphics g;

        private void OnNewFrameCallback(System.Drawing.Bitmap frame)
        {
            g.DrawImage(frame, Point.Empty);
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
                startToPlay = true;
                _mPlayer.Play();
                //form.BeginInvoke((Action)(() => form.label1.Text = ("Inainte de pendingFrames ... ")));
            }
        }
    }
}
