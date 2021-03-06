﻿
using System;
using Declarations;
using Declarations.Events;
using Declarations.Media;
using Declarations.Players;
using LibVlcWrapper;
using Implementation.Events;

namespace Implementation.Players
{
    internal class BasicPlayer : DisposableBase, IPlayer, IEventProvider, IReferenceCount, INativePointer
    {
        protected IntPtr m_hMediaPlayer;
        protected IntPtr m_hMediaLib;
        private readonly EventBroker m_events;
        IntPtr m_hEventManager = IntPtr.Zero;
        protected IMedia m_currentMedia;

        public BasicPlayer(IntPtr hMediaLib)
        {
            m_hMediaLib = hMediaLib;
            m_hMediaPlayer = LibVlcMethods.libvlc_media_player_new(m_hMediaLib);
            AddRef();
            m_events = new EventBroker(this);
        }

        #region IPlayer Members

        public virtual void Open(IMediaPlayerFactory factory, string s)
        {
            if (m_currentMedia != null)
            {
                m_currentMedia.Dispose();
            }

            m_currentMedia = factory.CreateMedia<IMedia>(s);

            LibVlcMethods.libvlc_media_player_set_media(m_hMediaPlayer, ((INativePointer)m_currentMedia).Pointer);
            //LibVlcMethods.libvlc_media_release(((INativePointer)m_currentMedia).Pointer);

        }

        public virtual void Open(IMedia media)
        {
            if (m_currentMedia != null)
            {
                m_currentMedia.Dispose();
            }

            m_currentMedia = media;

            LibVlcMethods.libvlc_media_player_set_media(m_hMediaPlayer, ((INativePointer)m_currentMedia).Pointer);
            LibVlcMethods.libvlc_media_release(((INativePointer)m_currentMedia).Pointer);

        }

        public virtual void Play()
        {
            LibVlcMethods.libvlc_media_player_play(m_hMediaPlayer);
        }

        public void Pause()
        {
            LibVlcMethods.libvlc_media_player_pause(m_hMediaPlayer);
        }

        public virtual void Stop()
        {
            LibVlcMethods.libvlc_media_player_stop(m_hMediaPlayer);

            if (m_currentMedia != null)
            {
                m_events.RaiseMediaEnded();
                m_currentMedia.Dispose();
                m_currentMedia = null;
            }
        }

        public long Time
        {
            get
            {
                return LibVlcMethods.libvlc_media_player_get_time(m_hMediaPlayer);
            }
            set
            {
                LibVlcMethods.libvlc_media_player_set_time(m_hMediaPlayer, value);
            }
        }

        public float Position
        {
            get
            {
                return LibVlcMethods.libvlc_media_player_get_position(m_hMediaPlayer);
            }
            set
            {
                LibVlcMethods.libvlc_media_player_set_position(m_hMediaPlayer, value);
            }
        }

        public long Length
        {
            get
            {
                return LibVlcMethods.libvlc_media_player_get_length(m_hMediaPlayer);
            }
        }

        public IEventBroker Events
        {
            get
            {
                return m_events;
            }
        }

        public bool IsPlaying
        {
            get
            {
                return LibVlcMethods.libvlc_media_player_is_playing(m_hMediaPlayer) == 1;
            }
        }

        public IMedia CurrentMedia
        {
            get
            {
                return m_currentMedia;
            }
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            Release();
        }

        #region IEventProvider Members

        public IntPtr EventManagerHandle
        {
            get
            {
                if (m_hEventManager == IntPtr.Zero)
                {
                    m_hEventManager = LibVlcMethods.libvlc_media_player_event_manager(m_hMediaPlayer);
                }

                return m_hEventManager;
            }
        }

        #endregion

        #region IReferenceCount Members

        public void AddRef()
        {
            LibVlcMethods.libvlc_media_player_retain(m_hMediaPlayer);
        }

        public void Release()
        {
            try
            {
                LibVlcMethods.libvlc_media_player_release(m_hMediaPlayer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region IEqualityComparer<IPlayer> Members

        public bool Equals(IPlayer x, IPlayer y)
        {
            INativePointer x1 = (INativePointer)x;
            INativePointer y1 = (INativePointer)y;

            return x1.Pointer == y1.Pointer;
        }

        public int GetHashCode(IPlayer obj)
        {
            return ((INativePointer)obj).Pointer.GetHashCode();
        }

        #endregion

        #region INativePointer Members

        public IntPtr Pointer
        {
            get { return m_hMediaPlayer; }
        }

        #endregion

        public override bool Equals(object obj)
        {
            return this.Equals((IPlayer)obj, this);
        }

        public override int GetHashCode()
        {
            return m_hMediaPlayer.GetHashCode();
        }
    }
}
