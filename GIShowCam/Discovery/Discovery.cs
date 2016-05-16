using Declarations.Discovery;
using Implementation.Discovery;
using System;

namespace GIShowCam.Discovery
{
    
    class Discovery
    {

        IMediaDiscoverer seeker;

        /// <summary>
        /// Cauta camere prin retea
        /// </summary>
        /// <returns></returns>
        internal Discovery()
        {
            seeker = new MediaDiscoverer(new IntPtr(), "Seeker");
        }

    }
}
