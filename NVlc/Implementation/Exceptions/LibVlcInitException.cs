
using System;

namespace Implementation.Exceptions
{
    /// <summary>
    /// Exception thrown when libVLC initialization failed.
    /// </summary>
    [Serializable]
    public class LibVlcInitException : LibVlcException
    {
        const string msg = "Failed to initialize libVLC. Possible reasons : Some of the arguments may be incorrect. VLC dlls' version mismatch.";

        public LibVlcInitException()
            : base(msg)
        {

        }
    }
}
