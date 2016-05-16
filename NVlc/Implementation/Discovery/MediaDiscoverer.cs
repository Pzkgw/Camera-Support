
using System;
using Declarations;
using Declarations.Discovery;
using Declarations.Events;
using Declarations.Media;
using Implementation.Events;
using Implementation.Media;
using LibVlcWrapper;
using System.Runtime.InteropServices;

namespace Implementation.Discovery
{
    public class MediaDiscoverer : DisposableBase, IMediaDiscoverer, INativePointer, IEventProvider
    {
        private IntPtr m_hDiscovery = IntPtr.Zero;
        private IMediaDiscoveryEvents m_events;

        public MediaDiscoverer(IntPtr hMediaLib, string name)
        {
            m_hDiscovery = LibVlcMethods.libvlc_media_discoverer_new_from_name(hMediaLib, name.ToUtf8());
        }

        protected override void Dispose(bool disposing)
        {
            LibVlcMethods.libvlc_media_discoverer_release(m_hDiscovery);
        }

        public bool IsRunning
        {
            get
            {
                return (LibVlcMethods.libvlc_media_discoverer_is_running(m_hDiscovery) == 1);
            }
        }

        public string LocalizedName
        {
            get
            {
                IntPtr pData = LibVlcMethods.libvlc_media_discoverer_localized_name(m_hDiscovery);
                return Marshal.PtrToStringAnsi(pData);
            }
        }

        public IMediaList MediaList
        {
            get
            {
                return new MediaList(LibVlcMethods.libvlc_media_discoverer_media_list(m_hDiscovery), ReferenceCountAction.None);
            }
        }

        public IntPtr EventManagerHandle
        {
            get 
            {
                return LibVlcMethods.libvlc_media_discoverer_event_manager(m_hDiscovery);
            }
        }

        public IntPtr Pointer
        {
            get 
            {
                return m_hDiscovery;
            }
        }

        public IMediaDiscoveryEvents Events
        {
            get
            {
                if (m_events == null)
                {
                    m_events = new MediaDiscoveryEventManager(this);
                }

                return m_events;
            }
        }
    }
}
