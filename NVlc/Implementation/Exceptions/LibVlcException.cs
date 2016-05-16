
using System;
using LibVlcWrapper;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Implementation.Exceptions
{
    /// <summary>
    /// Throws an exception with the latest error message.
    /// </summary>
    [Serializable]
    public class LibVlcException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the LibVlcException class with the last error that occurred.
        /// </summary>
        public LibVlcException()
            : base(Marshal.PtrToStringAnsi(LibVlcMethods.libvlc_errmsg()))
        {
            MessageBox.Show(base.Message);
        }

        public LibVlcException(string message)
            : base(message)
        {
        }
    }
}
