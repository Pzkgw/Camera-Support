using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIShowCam.Utils
{
    class UISync
    {
        private static ISynchronizeInvoke Sync;
        internal static bool on = true;

        internal static void Init(ISynchronizeInvoke sync)
        {
            Sync = sync;
        }

        internal static void Execute(Action action)//, params object[] args
        {
            if (on) Sync.BeginInvoke(action, null);
        }
    }
}
