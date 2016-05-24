using System;
using System.Text;
using System.Windows.Forms;
using Declarations;
using GIShowCam.Info;

namespace GIShowCam.Utils
{
    internal class CLogger : ILogger
    {
        private readonly TextBoxBase[] _logView;
        private DateTime _dt;

        private StringBuilder _debugSave = new StringBuilder();
        private bool _debugSaveDone;
        private byte _debugSaveStart;

        internal static bool On = true;

        internal CLogger(params TextBoxBase[] logView)
        {
            _logView = logView;

            _debugSaveDone = false;
            _debugSaveStart = 0;
        }


        private string GestLogString(string s)
        {
            _dt = DateTime.Now;
            return string.Format(" {0:00}:{1:00}:{2:00}.{3:000}    " + s + Environment.NewLine,
                        _dt.Hour, _dt.Minute, _dt.Second, _dt.Millisecond);
        }

        private void DebugSaveDoEEt(string s)
        {
            _logView[0].AppendText(_debugSave + GestLogString(s));
            _debugSave = null;
        }

        void ILogger.Debug(string debug)
        {
            if (!On) return;

            if (SessionInfo.Playing)
            {
                if (_debugSaveDone)
                {
                    UiSync.Execute(() => _logView[0].AppendText(GestLogString(debug)));
                }
                else
                {
                    _debugSaveDone = true;
                    UiSync.Execute(() => DebugSaveDoEEt(debug));
                }
            }
            else
            {
                if (_debugSaveDone) return;
                if (_debugSaveStart > 2)
                {
                    (new System.Threading.Thread(() => _debugSave.Append(GestLogString(debug)))).Start();
                }

                ++_debugSaveStart;
            }
        }

        void ILogger.Error(string error)
        {
            if (On)
                UiSync.Execute(() => _logView[1].Text += GestLogString(error));
        }

        void ILogger.Info(string info)
        {
            if (On)
                UiSync.Execute(() => _logView[2].Text += GestLogString(info));
        }

        void ILogger.Warning(string warn)
        {
            if (On)
                UiSync.Execute(() => _logView[3].Text += GestLogString(warn));
        }

    }
}
