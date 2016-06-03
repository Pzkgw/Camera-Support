using Declarations;
using Declarations.Players;
using Implementation;
using System;


namespace GISendApp
{
    class MainSend
    {
        private IMediaPlayerFactory _mFactory;
        //private IMemoryRenderer _memRender;
        private IDiskPlayer _mPlayer;
        //private IMedia _mMedia;


        string[] opt = new[] { //--snapshot-format=jpg
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

                _mPlayer = _mFactory.CreatePlayer<IDiskPlayer>();
            }

            DateTime _dt;

            while (true)//for (int i = 0; i < 128; i++)
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


        private void ToggleRunningMedia(bool on)
        {
            if (on)
            {
                _mPlayer.Open(_mFactory, s[si]);
                _mPlayer.Play();

                ToggleDrawing(true);
            }
            else
            {
                _mPlayer.Stop();
            }
        }

        //public delegate void NewFrameDataEventHandler(PlanarFrame frame);

        void NewFrameDat(PlanarFrame frame)
        {
            Console.WriteLine(frame.Lenghts);
            /*
            System.Threading.Tasks.Parallel.ForEach(m_renders, rnd => rnd.Display(frame.Planes[0], frame.Planes[1], frame.Planes[2], true));
            // Exception is thrown here  -- Display play time in milliseconds      
             
            m_renders[0].RemoveOverlay(0);
            m_renders[0].AddTextOverlay(0, m_player.Time.ToString(), new Rectangle(20, 20, 100, 40), 24, Color.Red, "Sans serif", 255);
            */


        }

        private void ToggleDrawing(bool on)
        {
            if (on)
            {
                //_memRender = _mPlayer.CustomRenderer;

                //_mPlayer.WindowHandle = _form.panelVlc.Handle;  

                _mPlayer.CustomRendererEx.SetCallback(delegate (PlanarFrame frame)
                {
                    //_panGraphics.DrawImageUnscaled(frame, Point.Empty);
                    Console.WriteLine("Frame");//frame.Lenghts);
                });

                //_memRender.SetFormat(_info.ImgFormat);
            }
            else
            {
                //_mPlayer.WindowHandle = IntPtr.Zero;

            }
        }




    }
}
