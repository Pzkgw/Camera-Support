
using System;
using Declarations.Events;
using LibVlcWrapper;

namespace Implementation.Events
{
    class MediaDiscoveryEventManager : EventManager, IMediaDiscoveryEvents
    {
        public MediaDiscoveryEventManager(IEventProvider eventProvider)
            : base(eventProvider)
        {

        }

        protected override void MediaPlayerEventOccured(ref libvlc_event_t libvlc_event, IntPtr userData)
        {
            switch(libvlc_event.type)
            {
                case libvlc_event_e.libvlc_MediaDiscovererStarted:

                    break;

                case libvlc_event_e.libvlc_MediaDiscovererEnded:

                    break;
            }
        }

        private event EventHandler m_mediaDiscoveryStarted;
        public event EventHandler MediaDiscoveryStarted
        {
            add
            {
                if (m_mediaDiscoveryStarted == null)
                {
                    Attach(libvlc_event_e.libvlc_MediaDiscovererStarted);
                }
                m_mediaDiscoveryStarted += value;
            }
            remove
            {
                if (m_mediaDiscoveryStarted != null)
                {
                    m_mediaDiscoveryStarted -= value;
                    if (m_mediaDiscoveryStarted == null)
                    {
                        Dettach(libvlc_event_e.libvlc_MediaDiscovererStarted);
                    }
                }
            }
        }

        private event EventHandler m_mediaDiscoveryEnded;
        public event EventHandler MediaDiscoveryEnded
        {
            add
            {
                if (m_mediaDiscoveryEnded == null)
                {
                    Attach(libvlc_event_e.libvlc_MediaDiscovererEnded);
                }
                m_mediaDiscoveryEnded += value;
            }
            remove
            {
                if (m_mediaDiscoveryEnded != null)
                {
                    m_mediaDiscoveryEnded -= value;
                    if (m_mediaDiscoveryEnded == null)
                    {
                        Dettach(libvlc_event_e.libvlc_MediaDiscovererEnded);
                    }
                }
            }
        }      
    }
}
