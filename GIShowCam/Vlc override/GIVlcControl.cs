

using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Windows.Forms;
using Vlc.DotNet.Core;
using Vlc.DotNet.Core.Interops.Signatures;
using Vlc.DotNet.Forms;
using Vlc.DotNet.Forms.TypeEditors;

namespace GIShowCam.Vlc_override
{
    internal partial class GIVlcControl : Control, ISupportInitialize
    {

        internal bool initEndNeeded;


        private VlcMediaPlayer myVlcMediaPlayer;

        #region VlcControl Init

        public GIVlcControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Init Component behaviour
            BackColor = System.Drawing.Color.Black;
        }

        [Category("Media Player")]
        public string[] VlcMediaplayerOptions { get; set; }

        [Category("Media Player")]
        [Editor(typeof(DirectoryEditor), typeof(UITypeEditor))]
        public DirectoryInfo VlcLibDirectory { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool IsPlaying
        {
            get
            {
                if (myVlcMediaPlayer != null)
                {
                    return myVlcMediaPlayer.IsPlaying();
                }
                else
                {
                    return false;
                }
            }
        }

        public void BeginInit()
        {
            // not used yet
        }

        public void EndInit()
        {
            if (IsInDesignMode() || myVlcMediaPlayer != null)
                return;
            if (VlcLibDirectory == null && (VlcLibDirectory = OnVlcLibDirectoryNeeded()) == null)
            {
                throw new Exception("'VlcLibDirectory' must be set.");
            }

            if (VlcMediaplayerOptions == null)
            {
                myVlcMediaPlayer = new VlcMediaPlayer(VlcLibDirectory);
            }
            else
            {
                myVlcMediaPlayer = new VlcMediaPlayer(VlcLibDirectory, VlcMediaplayerOptions);
            }
            myVlcMediaPlayer.VideoHostControlHandle = Handle;
            RegisterEvents();
        }

        private static bool IsInDesignMode()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().Location.Contains("VisualStudio");
        }

        public event EventHandler<VlcLibDirectoryNeededEventArgs> VlcLibDirectoryNeeded;

        bool disposed = false;

        internal new void Dispose()
        {
            base.Dispose();
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (myVlcMediaPlayer != null)
                    {
                        UnregisterEvents();
                        if (IsPlaying)
                            Stop(false);
                       // myVlcMediaPlayer.Dispose();
                    }
                    myVlcMediaPlayer = null;
                    base.Dispose(disposing);
                }
                disposed = true;
            }
        }

        public DirectoryInfo OnVlcLibDirectoryNeeded()
        {
            var del = VlcLibDirectoryNeeded;
            if (del != null)
            {
                var args = new VlcLibDirectoryNeededEventArgs();
                del(this, args);
                return args.VlcLibDirectory;
            }
            return null;
        }
        #endregion

        #region VlcControl Functions & Properties

        public void Play()
        {
            //EndInit();
            if (myVlcMediaPlayer != null)
            {
                myVlcMediaPlayer.Play();
            }
        }

        public void Play(FileInfo file, params string[] options)
        {
            //EndInit();
            if (myVlcMediaPlayer != null)
            {
                myVlcMediaPlayer.SetMedia(file, options);
                Play();
            }
        }

        public void Play(Uri uri, params string[] options)
        {
            //EndInit();
            if (myVlcMediaPlayer != null)
            {
                myVlcMediaPlayer.SetMedia(uri, options);
                Play();
            }
        }

        public void Play(string mrl, params string[] options)
        {
            //EndInit();
            if (myVlcMediaPlayer != null)
            {
                lock (myEventSyncLocker)
                {
                    myVlcMediaPlayer.SetMedia(mrl, options);
                    //(new System.Threading.Thread(delegate () { Play(); })).Start();
                    Play();
                }
            }
        }


        public void SetMedia(FileInfo file, params string[] options)
        {
            myVlcMediaPlayer.SetMedia(file, options);
        }


        public void SetMedia(Uri file, params string[] options)
        {
            SetMedia(file.AbsolutePath, options);
        }
          public void SetMedia(string mrl, params string[] options)
        {
            myVlcMediaPlayer.SetMedia(mrl, options);
        }
        public void Pause()
        {
            //EndInit();
            if (myVlcMediaPlayer != null)
            {
                lock (myEventSyncLocker)
                {
                    myVlcMediaPlayer.Pause();
                }
            }
        }

        public void Stop(bool preDel)
        {
            //EndInit();
            if (myVlcMediaPlayer != null)
            {
                lock (myEventSyncLocker)
                {
                    myVlcMediaPlayer.Stop();
                    if (preDel) myVlcMediaPlayer.Dispose();
                }
            }
        }

        public VlcMedia GetCurrentMedia()
        {
            //EndInit();
            if (myVlcMediaPlayer != null)
            {
                return myVlcMediaPlayer.GetMedia();
            }
            else
            {
                return null;
            }
        }

        public void TakeSnapshot(string fileName)
        {
            myVlcMediaPlayer.TakeSnapshot(new FileInfo(fileName));
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public float Position
        {
            get
            {
                if (myVlcMediaPlayer != null)
                {
                    return myVlcMediaPlayer.Position;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                if (myVlcMediaPlayer != null)
                {
                    myVlcMediaPlayer.Position = value;
                }

            }
        }

        [Browsable(false)]
        public IChapterManagement Chapter
        {
            get
            {
                if (myVlcMediaPlayer != null)
                {
                    return myVlcMediaPlayer.Chapters;
                }
                else
                {
                    return null;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public float Rate
        {
            get
            {
                if (myVlcMediaPlayer != null)
                {
                    return myVlcMediaPlayer.Rate;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                if (myVlcMediaPlayer != null)
                {
                    myVlcMediaPlayer.Rate = value;
                }
            }
        }

        [Browsable(false)]
        public MediaStates State
        {
            get
            {
                if (myVlcMediaPlayer != null)
                {
                    return myVlcMediaPlayer.State;
                }
                else
                {
                    return MediaStates.NothingSpecial;
                }
            }
        }

        [Browsable(false)]
        public ISubTitlesManagement SubTitles
        {
            get
            {
                if (myVlcMediaPlayer != null)
                {
                    return myVlcMediaPlayer.SubTitles;
                }
                else
                {
                    return null;
                }

            }
        }

        [Browsable(false)]
        public IVideoManagement Video
        {
            get
            {
                if (myVlcMediaPlayer != null)
                {
                    return myVlcMediaPlayer.Video;
                }
                else
                {
                    return null;
                }
            }
        }

        [Browsable(false)]
        public IAudioManagement Audio
        {
            get
            {
                if (myVlcMediaPlayer != null)
                {
                    return myVlcMediaPlayer.Audio;
                }
                else
                {
                    return null;
                }
            }
        }

        [Browsable(false)]
        public long Length
        {
            get
            {
                if (myVlcMediaPlayer != null)
                {
                    return myVlcMediaPlayer.Length;
                }
                else
                {
                    return -1;
                }

            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public long Time
        {
            get
            {
                if (myVlcMediaPlayer != null)
                {
                    return myVlcMediaPlayer.Time;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                if (myVlcMediaPlayer != null)
                {
                    myVlcMediaPlayer.Time = value;
                }
            }
        }

        [Browsable(false)]
        public int Spu
        {
            get
            {
                if (myVlcMediaPlayer != null)
                {
                    return myVlcMediaPlayer.Spu;
                }
                return -1;
            }
            set
            {
                if (myVlcMediaPlayer != null)
                {
                    myVlcMediaPlayer.Spu = value;
                }
            }
        }

      #endregion



    }
}
