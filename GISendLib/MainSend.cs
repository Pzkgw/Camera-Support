using Declarations;
using Declarations.Events;
using Declarations.Media;
using Declarations.Players;
using Implementation;
using System;
using System.Threading;

namespace GISendLib
{
    public class MainSend
    {
        private IMediaPlayerFactory _mFactory;
        //private IMemoryRenderer _memRender;
        public IVideoPlayer Player;
        public IMemoryInputMedia InputMedia;


        const long MicroSecondsInSecomd = 1000 * 1000;
        long MicroSecondsBetweenFrame;
        long frameCounter;
        //FrameData data = new FrameData() { DTS = -1 };
        const int DefaultFps = 30;

        string adr;

        string[] opt = new string[] {
            //--snapshot-format=jpg
                //"-I", "dumy", "--ignore-config", "--no-osd", "--disable-screensaver", "--plugin-path=./plugins"
                /*,"--no-fullscreen" //
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
                ,"--no-snapshot-preview"*/
                "--quiet" // quiet- deactivates all console messages  
                ,"--no-sout-audio" //        ^^^  Enable audio stream output (default enabled)
                ,"--aout=none" //  main NO audio output ( optional mai e si "--no-audio" )

        };

        public bool MediaRunning;

        public MainSend()
        {
            _mFactory = new MediaPlayerFactory(opt,//new string[] { },
                @"C:\Program Files (x86)\VideoLAN\VLC", true, new CLogger());

            InputMedia = _mFactory.CreateMedia<IMemoryInputMedia>(MediaStrings.IMEM);

            Player = _mFactory.CreatePlayer<IVideoPlayer>();


            Player.Events.PlayerPlaying += new EventHandler(Events_PlayerPlaying);

            /*
            //DateTime _dt;

            for (int i = 0; i < 2; i++)//while (true)
            {
            //_dt = DateTime.Now;

            if (started) ToggleRunningMedia(false);

            //_dt = DateTime.Now;
            //Console.WriteLine(string.Format(" {0:00}:{1:00}:{2:00}.{3:000}    {4}",
            //   _dt.Hour, _dt.Minute, _dt.Second, _dt.Millisecond, "Stop"));

            


            ++si;                if (si >= s.Length) si = 0;
            //_dt = DateTime.Now;
            //Console.WriteLine(string.Format(" {0:00}:{1:00}:{2:00}.{3:000}    {4}{5}",
            //_dt.Hour, _dt.Minute, _dt.Second, _dt.Millisecond, "Start", Environment.NewLine));

            started = true;
            }*/

        }

        public int PlayStart(string adr)
        {
            this.adr = adr;
            ToggleRunningMedia(true);
            return 0;
        }

        public void PlayStop()
        {
            ToggleRunningMedia(false);
        }

        void Events_PlayerPlaying(object sender, EventArgs e)
        {
            ((Action)(() => MicroSecondsBetweenFrame = (long)(MicroSecondsInSecomd / (Player.FPS != 0 ? Player.FPS : DefaultFps)))).DynamicInvoke();
        }


        private void ToggleRunningMedia(bool on)
        {
            MediaRunning = on;

            if (on)
            {
                //Thread.Sleep(3000);
                ToggleDrawing(true); // inainte de play
                Player.Open(_mFactory, adr);
                //Player.CurrentMedia.Events.StateChanged += Events_StateChanged;


                Player.Play();
            }
            else
            {
                Player.Stop();
                ToggleDrawing(false);
                //Player.CurrentMedia.Events.StateChanged -= Events_StateChanged;


            }
        }
        /*
        public event EventHandler<MediaStateChange> StateChanged;

        private void Events_StateChanged(object sender, MediaStateChange e)
        {
            try
            {
                switch (e.NewState)
                {
                    case MediaState.Opening:
                        //_info.Cam.Data.IsOpening = true;
                        break;
                    case MediaState.Buffering:
                        //_info.Cam.Data.IsBuffering = true;
                        break;
                    case MediaState.Playing:
                        //_info.Cam.Data.IsPlaying = true;
                        break;
                    case MediaState.Paused:
                        //_info.Cam.Data.IsPaused = true;
                        break;
                    case MediaState.Stopped:
                        //if (!SessionInfo.FullScreen && !_info.Cam.Data.IsStopped)                        {
                        //   _form.BeginInvoke((Action)(() => SetBtnsVisibilityOnPlay(false)));                        }
                        //_info.Cam.Data.IsStopped = true;
                        break;
                    case MediaState.Ended:
                    case MediaState.Error:
                        ToggleRunningMedia(false);
                        ToggleRunningMedia(true);
                        break;
                    case MediaState.NothingSpecial:
                        break;
                }

                StateChanged?.Invoke(sender, e);

                //CLogger.VideoOnPlay = _info.Cam.Data.IsPlaying;
            }
            finally
            {
                //if (locked)                    Monitor.Exit(_lockStateModif);
            }
        }*/

        private void ToggleDrawing(bool on)
        {
            if (on)
            {
                Player.CustomRendererEx.SetExceptionHandler(OnExceptionCallback);


                //Player.CustomRenderer.SetCallback(OnNewFrameCallback);
                Player.CustomRendererEx.SetFormatSetupCallback(OnSetupCallback);
                //_mPlayer.CustomRendererEx.SetExceptionHandler(OnErrorCallbackEx);
                Player.CustomRendererEx.SetCallback(OnNewFrameCallbackEx);

                //OnSetupCallback(new BitmapFormat(640, 386, ChromaType.J420));
            }
            else
            {
                Player.CustomRendererEx.Dispose();
                //Player.CustomRendererEx.SetFormatSetupCallbackEx(null);
                //_mPlayer.CustomRendererEx.SetExceptionHandlerEx(null);
                //Player.CustomRendererEx.SetCallbackEx(null);
            }
        }

        private void OnExceptionCallback(Exception ex)
        {

        }

        private BitmapFormat OnSetupCallback(BitmapFormat format)
        {
            return SetupInput(format);
        }
        /*
        private void OnErrorCallback(Exception error)
        {
            ToggleRunningMedia(false);
            ToggleRunningMedia(true);
            //MessageBox.Show(error.Message);
        }*/

        private void OnNewFrameCallback(System.Drawing.Bitmap frame)
        {

        }


        object _lockStateModif = new object();
        FrameData data = new FrameData();
        private void OnNewFrameCallbackEx(PlanarFrame frame)
        {
            Monitor.Enter(_lockStateModif);
            try
            {
                /*
            data.Data = frame.Planes[0];
            data.DataSize = frame.Lenghts[0];
            data.PTS = frameCounter++ * MicroSecondsBetweenFrame;

            InputMedia.AddFrame(data); // DTS ramane pe default ( -1 )

            for (int i = 0; i < frame.Planes.Length; frame.Planes[i++] = IntPtr.Zero) ;*/

                //if (/*m_inputMedia.PendingFramesCount == 10 && */!Player.IsPlaying) { Player.Play(); }

                data = new FrameData() { Data = frame.Planes[0], DataSize = frame.Lenghts[0], DTS = -1, PTS = frameCounter++ * MicroSecondsBetweenFrame };
                InputMedia.AddFrame(data);
                //data.
                //InputMedia.AddFrame(new FrameData() { Data = frame.Planes[1], DataSize = frame.Lenghts[1], DTS = -1, PTS = frameCounter++ * MicroSecondsBetweenFrame });
                //InputMedia.AddFrame(new FrameData() { Data = frame.Planes[2], DataSize = frame.Lenghts[2], DTS = -1, PTS = frameCounter++ * MicroSecondsBetweenFrame });
            }
            finally
            {
                Monitor.Exit(_lockStateModif);
            }

        }


        private BitmapFormat SetupInput(BitmapFormat format)
        {
            var streamInfo = new StreamInfo();
            streamInfo.Category = Declarations.Enums.StreamCategory.Video;
            streamInfo.Codec = Declarations.Enums.VideoCodecs.BGR24;
            streamInfo.Width = format.Width;
            streamInfo.Height = format.Height;
            streamInfo.Size = format.ImageSize;

            InputMedia.Initialize(streamInfo, 36);
            //InputMedia.SetExceptionHandler(OnErrorCallback);
            //m_renderPlayer.Open(m_inputMedia);

            //Player.Open(_mFactory, s[si]);

            return new BitmapFormat(format.Width, format.Height, ChromaType.RV24);
        }




    }
}
