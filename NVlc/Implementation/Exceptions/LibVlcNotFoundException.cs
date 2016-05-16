
using System;

namespace Implementation.Exceptions
{
    /// <summary>
    /// Exception thrown when one of the vlc libraries are missing.
    /// </summary>
    [Serializable]
    public class LibVlcNotFoundException : DllNotFoundException
    {
        const string msg = "Failed to load VLC modules. Make sure libvlc.dll, libvlccore.dll and plugins directory located in the executable path.";

        public LibVlcNotFoundException()
            : base(msg)
        {

        }

        public LibVlcNotFoundException(Exception ex)
            : base(msg, ex)
        {
        }
    }
}
