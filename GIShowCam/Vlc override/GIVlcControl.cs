

using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Vlc.DotNet.Core;
using Vlc.DotNet.Core.Interops.Signatures;

namespace GIShowCam.Vlc_override
{
    internal partial class GIVlcControl : Control, ISupportInitialize
    {

        internal bool initEndNeeded;


        private VlcMediaPlayer myVlcMediaPlayer;

        #region VlcControl Init

        internal GIVlcControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Init Component behaviour
            BackColor = System.Drawing.Color.Black;
        }

        [Category("Media Player")]
        internal string[] VlcMediaplayerOptions { get; set; }

        internal DirectoryInfo VlcLibDirectory { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        internal bool IsPlaying
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
            if (VlcLibDirectory == null)
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



        bool disposed = false;

        internal new void Dispose()
        {
            base.Dispose();
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal void CleanUp()
        {
            if (myVlcMediaPlayer != null)
            {
                UnregisterEvents();
                if (IsPlaying) Stop(true);
            }
            myVlcMediaPlayer = null;
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

        #endregion

        #region VlcControl Functions & Properties

        internal void Play()
        {
            myVlcMediaPlayer.Play();
        }

        internal void Play(FileInfo file, params string[] options)
        {
            myVlcMediaPlayer.SetMedia(file, options);
            Play();

        }

        internal void Play(Uri uri, params string[] options)
        {
            myVlcMediaPlayer.SetMedia(uri, options);
            Play();

        }

        internal void Play(string mrl, params string[] options)
        {

            lock (myEventSyncLocker)
            {
                myVlcMediaPlayer.SetMedia(mrl, options);
                //(new System.Threading.Thread(delegate () { Play(); })).Start();
                Play();
            }

        }


        internal void SetMedia(FileInfo file, params string[] options)
        {
            myVlcMediaPlayer.SetMedia(file, options);
        }


        internal void SetMedia(Uri file, params string[] options)
        {
            SetMedia(file.AbsolutePath, options);
        }
        internal void SetMedia(string mrl, params string[] options)
        {
            myVlcMediaPlayer.SetMedia(mrl, options);
        }
        internal void Pause()
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

        //momentan: preDelete doar la final
        internal void Stop(bool preDel)
        {
            //EndInit();
            if (myVlcMediaPlayer != null)
            {
                lock (myEventSyncLocker)
                {
                    myVlcMediaPlayer.Stop();
                    if (preDel)
                    {
                        myVlcMediaPlayer.Dispose();
                        myVlcMediaPlayer = null;
                        //myVlcMediaPlayer.DisposeMedia();
                    }
                }
            }
        }

        internal VlcMedia GetCurrentMedia()
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

        internal void TakeSnapshot(string fileName)
        {
            myVlcMediaPlayer.TakeSnapshot(new FileInfo(fileName));
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        internal float Position
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
        internal IChapterManagement Chapter
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
        internal float Rate
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
        internal MediaStates State
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
        internal ISubTitlesManagement SubTitles
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
        internal IVideoManagement Video
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
        internal IAudioManagement Audio
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
        internal long Length
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
        internal long Time
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
        internal int Spu
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
