
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Declarations;
using Declarations.Events;
using LibVlcWrapper;

namespace Implementation.Events
{
    internal abstract class EventManager
    {
        protected IEventProvider m_eventProvider;
        List<VlcEventHandlerDelegate> m_callbacks = new List<VlcEventHandlerDelegate>();
        IntPtr hCallback1;

        protected EventManager(IEventProvider eventProvider)
        {
            m_eventProvider = eventProvider;

            VlcEventHandlerDelegate callback1 = MediaPlayerEventOccured;

            hCallback1 = Marshal.GetFunctionPointerForDelegate(callback1);
            m_callbacks.Add(callback1);
        }

        protected void Attach(libvlc_event_e eType)
        {
            if (LibVlcMethods.libvlc_event_attach(m_eventProvider.EventManagerHandle, eType, hCallback1, IntPtr.Zero) != 0)
            {
                throw new OutOfMemoryException("Failed to subscribe to event notification");
            }
        }

        protected void Dettach(libvlc_event_e eType)
        {
            LibVlcMethods.libvlc_event_detach(m_eventProvider.EventManagerHandle, eType, hCallback1, IntPtr.Zero);
        }

        protected abstract void MediaPlayerEventOccured(ref libvlc_event_t libvlc_event, IntPtr userData);
    }
}
