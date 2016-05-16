
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Declarations.Enums
{
    /// <summary>
    /// Audio output device types
    /// </summary>
    public enum AudioOutputDeviceType
    {
        AudioOutputDevice_Error = -1,
        AudioOutputDevice_Mono = 1,
        AudioOutputDevice_Stereo = 2,
        AudioOutputDevice_2F2R = 4,
        AudioOutputDevice_3F2R = 5,
        AudioOutputDevice_5_1 = 6,
        AudioOutputDevice_6_1 = 7,
        AudioOutputDevice_7_1 = 8,
        AudioOutputDevice_SPDIF = 10
    }
}
