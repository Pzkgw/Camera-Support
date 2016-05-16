
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibVlcWrapper
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class MinimalLibVlcVersion : Attribute
    {
        public MinimalLibVlcVersion(string minVersion)
        {
            MinimalVersion = minVersion;
        }

        public string MinimalVersion { get; private set; }
    }
}
