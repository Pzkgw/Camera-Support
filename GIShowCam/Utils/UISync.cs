using System;
using System.ComponentModel;

namespace GIShowCam.Utils
{
    internal static class UiSync
    {
        private static ISynchronizeInvoke _sync;

        internal static void SetSyncObj(ISynchronizeInvoke sync)
        {
            _sync = sync;
        }

        internal static void Execute(Action action)//, params object[] args
        {
            if (_sync != null) _sync.BeginInvoke(action, null);
        }
    }
}
