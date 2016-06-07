using Declarations;
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
        private IVideoPlayer _mPlayer;
        public IMemoryInputMedia InputMedia;


        const long MicroSecondsInSecomd = 1000 * 1000;
        long MicroSecondsBetweenFrame;
        long frameCounter;
        FrameData data = new FrameData() { DTS = -1 };
        const int DefaultFps = 24;


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

        string[] s = new[] {
            @"rtsp://admin:admin@10.10.10.202:554/cam/realmonitor?channel=1&subtype=0",
            @"rtsp://root:cavi123,.@10.10.10.78/axis-media/media.amp"
        };
        int si = 0;

        bool started;

        public MainSend()
        {
            
            if (_mFactory == null)
            {
                _mFactory = new MediaPlayerFactory(opt,//new string[] { },
                    @"C:\Program Files (x86)\VideoLAN\VLC", false, new CLogger());

                _mPlayer = _mFactory.CreatePlayer<IVideoPlayer>();
                _mPlayer.Events.PlayerPlaying += new EventHandler(Events_PlayerPlaying);
                InputMedia = _mFactory.CreateMedia<IMemoryInputMedia>(MediaStrings.IMEM);
            }

            DateTime _dt;

            //while (true)//for (int i = 0; i < 128; i++)
            {
                _dt = DateTime.Now;

                if (started) ToggleRunningMedia(false);

                _dt = DateTime.Now;
                Console.WriteLine(string.Format(" {0:00}:{1:00}:{2:00}.{3:000}    {4}",
                    _dt.Hour, _dt.Minute, _dt.Second, _dt.Millisecond, "Stop"));


                ToggleRunningMedia(true);


                System.Threading.Thread.Sleep(3000);
                ++si;
                if (si >= s.Length) si = 0;
                _dt = DateTime.Now;
                Console.WriteLine(string.Format(" {0:00}:{1:00}:{2:00}.{3:000}    {4}{5}",
                    _dt.Hour, _dt.Minute, _dt.Second, _dt.Millisecond, "Start", Environment.NewLine));

                started = true;
            }

        }

        void Events_PlayerPlaying(object sender, EventArgs e)
        {
            MicroSecondsBetweenFrame = (long)(MicroSecondsInSecomd / (_mPlayer.FPS != 0 ? _mPlayer.FPS : DefaultFps));
        }


        private void ToggleRunningMedia(bool on)
        {
            if (on)
            {
                _mPlayer.Open(_mFactory, s[si]);
                _mPlayer.CurrentMedia.Events.StateChanged += Events_StateChanged;

                ToggleDrawing(true); // inainte de play

                _mPlayer.Play();
                
            }
            else
            {
                _mPlayer.Stop();
                _mPlayer.CurrentMedia.Events.StateChanged -= Events_StateChanged;
                ToggleDrawing(false);
            }
        }

        private static readonly object _lockStateModif = new object();

        private void Events_StateChanged(object sender, Declarations.Events.MediaStateChange e)
        {
            var locked = false;
            Monitor.Enter(_lockStateModif, ref locked);
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

                //CLogger.VideoOnPlay = _info.Cam.Data.IsPlaying;
            }
            finally
            {
                if (locked)
                    Monitor.Exit(_lockStateModif);
            }
        }

        private void ToggleDrawing(bool on)
        {
            if (on)
            {
                _mPlayer.CustomRendererEx.SetFormatSetupCallback(OnSetupCallback);
                //_mPlayer.CustomRendererEx.SetExceptionHandler(OnErrorCallback);
                _mPlayer.CustomRendererEx.SetCallback(OnNewFrameCallback);
            }
            else
            {
                _mPlayer.CustomRendererEx.SetFormatSetupCallback(null);
                //_mPlayer.CustomRendererEx.SetExceptionHandler(null);
                _mPlayer.CustomRendererEx.SetCallback(null);
            }
        }

        private BitmapFormat OnSetupCallback(BitmapFormat format)
        {
            SetupInput(format);
            return new BitmapFormat(format.Width, format.Height, ChromaType.RV24);
        }
        /*
        private void OnErrorCallback(Exception error)
        {
            ToggleRunningMedia(false);
            ToggleRunningMedia(true);
            //MessageBox.Show(error.Message);
        }*/

        private void OnNewFrameCallback(PlanarFrame frame)
        {
            data.Data = frame.Planes[0];
            data.DataSize = frame.Lenghts[0];
            data.PTS = frameCounter++ * MicroSecondsBetweenFrame;
            InputMedia.AddFrame(data);

            //if (/*m_inputMedia.PendingFramesCount == 10 && */!m_renderPlayer.IsPlaying)            {
            //    m_renderPlayer.Play();            }
        }


        private void SetupInput(BitmapFormat format)
        {
            var streamInfo = new StreamInfo();
            streamInfo.Category = Declarations.Enums.StreamCategory.Video;
            streamInfo.Codec = Declarations.Enums.VideoCodecs.BGR24;
            streamInfo.Width = format.Width;
            streamInfo.Height = format.Height;
            streamInfo.Size = format.ImageSize;

            InputMedia.Initialize(streamInfo);
            //InputMedia.SetExceptionHandler(OnErrorCallback);
            //m_renderPlayer.Open(m_inputMedia);
        }




    }
}
