
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Declarations.Events
{
    /// <summary>
    /// Events raised by media discoverer
    /// </summary>
    public interface IMediaDiscoveryEvents
    {
        event EventHandler MediaDiscoveryStarted;

        event EventHandler MediaDiscoveryEnded;
    }
}
