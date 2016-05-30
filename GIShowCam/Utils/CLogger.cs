using System;
using System.Text;
using System.Windows.Forms;
using Declarations;
using GIShowCam.Info;
using System.Threading;

namespace GIShowCam.Utils
{
    internal class CLogger : ILogger
    {
        private DateTime _dt;
        private FormMain _ctrl;

        internal bool On = true, VideoOnPlay;

        internal CLogger(FormMain form)
        {
            _ctrl = form;
        }

        private void Log(TextBoxBase txtBox, string s)
        {
            if (_ctrl != null)
            {
                Monitor.Enter(_ctrl);
                try
                {
                    if (On) _ctrl.BeginInvoke((Action)(() => txtBox.Text += GestLogString(s)));
                }
                finally
                {
                    Monitor.Exit(_ctrl);
                }
            }
        }

        private string GestLogString(string s)
        {
            _dt = DateTime.Now;
            return string.Format(" {0:00}:{1:00}:{2:00}.{3:000}    " + s + Environment.NewLine,
                        _dt.Hour, _dt.Minute, _dt.Second, _dt.Millisecond);
        }

        void ILogger.Debug(string debug)
        {
            Log(_ctrl?.txtLVDebug ?? null, debug);
        }

        void ILogger.Error(string error)
        {
            Log(_ctrl?.txtLVErrors ?? null, error);
        }

        void ILogger.Info(string info)
        {
            Log(_ctrl?.txtLVInfo ?? null, info);
        }

        void ILogger.Warning(string warn)
        {
            Log(_ctrl?.txtLVWarnings ?? null, warn);
        }

        internal void CleanUp()
        {
            On = false;
            _ctrl = null;
        }

    }
}
