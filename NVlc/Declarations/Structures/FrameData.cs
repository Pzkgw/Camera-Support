
using System;

namespace Declarations
{
    /// <summary>
    /// Data structure for single frame of elementary stream
    /// </summary>
    public struct FrameData
    {
        /// <summary>
        /// Pointer to the frame data
        /// </summary>
        public IntPtr Data { get; set; }

        /// <summary>
        /// Data size in bytes
        /// </summary>
        public int DataSize { get; set; }

        /// <summary>
        /// Decoding time stamp in microseconds. -1 means unknown
        /// </summary>
        public long DTS { get; set; }

        /// <summary>
        /// Presentation time stamp in microseconds.
        /// </summary>
        public long PTS { get; set; }
    }
}
