
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Declarations.Enums
{
    /// <summary>
    /// Video codecs supported by imem module (IMemoryInputMedia)
    /// </summary>
    public enum VideoCodecs
    {
        /// <summary>
        /// 24 bits per pixel blue, green and red
        /// </summary>
        [Description("RV24")]
        BGR24,

        /// <summary>
        /// 32 bits per pixel blue, green, red and empty (or alpha)
        /// </summary>
        [Description("RV32")]
        BGR32,

        /// <summary>
        /// Motion JPEG stream - each video frame encoded as jpeg image
        /// </summary>
        [Description("MJPG")]
        MJPEG,

        /// <summary>
        /// YUV420 12 bits per pixel Y, Cb and Cr
        /// </summary>
        [Description("I420")]
        I420
    }
}
