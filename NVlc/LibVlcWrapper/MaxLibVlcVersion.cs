
using System;


namespace LibVlcWrapper
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class MaxLibVlcVersion : Attribute
    {
        public MaxLibVlcVersion(string maxVersion, string libVlcModuleName)
        {
            MaxVersion = maxVersion;
            LibVlcModuleName = libVlcModuleName;
        }

        public string MaxVersion { get; private set; }
        public string LibVlcModuleName { get; private set; }
    }
}
