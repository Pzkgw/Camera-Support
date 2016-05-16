
using System;

namespace Declarations
{
    /// <summary>
    /// Information structure for audio and video filters
    /// </summary>
    [Serializable]
    public struct FilterInfo
    {
        public string Name;
        public string Shortname;
        public string Longname;
        public string Help;
    }
}
