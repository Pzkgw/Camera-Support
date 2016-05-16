
using System;

namespace Declarations
{
    /// <summary>
    /// Represents hardware audio output device such as sound card.
    /// </summary>
    [Serializable]
    public class AudioOutputDeviceInfo
    {
        public string Id;
        public string Longname;
    }

    /// <summary>
    /// Represents software audio output module such as Waveout.
    /// </summary>
    [Serializable]
    public class AudioOutputModuleInfo
    {
        public string Name;
        public string Description;
    }
}
