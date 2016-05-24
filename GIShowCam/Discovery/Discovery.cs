using Declarations;
using Declarations.Discovery;
using Declarations.Media;
using Implementation.Discovery;
using System;

namespace GIShowCam.Gui
{
    internal class Discovery
    {
        /// <summary>
        /// Cauta camere prin retea
        /// </summary>
        /// <returns></returns>
        internal Discovery(IMediaPlayerFactory factory)
        {
            //IMediaDiscoverer seeker;
            //seeker = factory.CreateMediaDiscoverer("Seeker"); //new MediaDiscoverer(new IntPtr(), "Seeker");
            //IMediaList ml = seeker.MediaList;
        }



        internal void CleanUp()
        {

        }

    }
}
