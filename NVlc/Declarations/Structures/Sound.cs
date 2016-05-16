
using System;

namespace Declarations
{
    /// <summary>
    /// Structure incapsulation for audio samples
    /// </summary>
    [Serializable]
    public struct Sound
    {
        /// <summary>
        /// Pointer to the first audio sample
        /// </summary>
        public IntPtr SamplesData { get; set; }

        /// <summary>
        /// Size in bytes of SamplesData buffer
        /// </summary>
        public uint SamplesSize { get; set; }

        /// <summary>
        /// Playback time stamp in microseconds
        /// </summary>
        public long Pts { get; set; }
    }
}
