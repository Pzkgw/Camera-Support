using System;
using System.ComponentModel;

namespace GIShowCam.Utils
{
    internal class UiSync
    {
        private static ISynchronizeInvoke _sync;
        internal static bool On = true;

        internal static void Init(ISynchronizeInvoke sync)
        {
            _sync = sync;
        }

        internal static void Execute(Action action)//, params object[] args
        {
            if (On) _sync.BeginInvoke(action, null);
        }
    }
}
