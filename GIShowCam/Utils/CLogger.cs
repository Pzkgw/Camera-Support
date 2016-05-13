using Declarations;
using GIShowCam.Info;
using GIShowCam.Utils;
using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace GIShowCam
{
    class CLogger : ILogger
    {
        TextBoxBase[] logView;
        DateTime _dt;

        StringBuilder debugSave = new StringBuilder();
        bool debugSaveDone = false;
        byte debugSaveStart = 0;

        internal static bool on = true;

        internal CLogger(params TextBoxBase[] logView)
        {
            this.logView = logView;
        }

        string GestLogString(string s)
        {
            _dt = DateTime.Now;
            return string.Format(" {0:00}:{1:00}:{2:00}.{3:000}    " + s + Environment.NewLine,
                        _dt.Hour, _dt.Minute, _dt.Second, _dt.Millisecond);
        }

        void debugSaveDoEEt(string s)
        {
            logView[0].Text += debugSave.ToString() + GestLogString(s);
            debugSave.Clear();
        }

        void ILogger.Debug(string debug)
        {
            if (on)
                if (SessionInfo.playing)
                {
                    if (debugSaveDone)
                    {
                        UISync.Execute(() => logView[0].Text += GestLogString(debug));
                    }
                    else
                    {
                        debugSaveDone = true;
                        UISync.Execute(() => debugSaveDoEEt(debug));
                    }
                }
                else
                {
                    if (debugSaveStart > 2)
                    {
                        (new System.Threading.Thread(delegate () { debugSave.Append(GestLogString(debug)); })).Start();
                    }

                    ++debugSaveStart;
                }
        }

        void ILogger.Error(string error)
        {
            UISync.Execute(() => logView[1].Text += GestLogString(error));
        }

        void ILogger.Info(string info)
        {
            UISync.Execute(() => logView[2].Text += GestLogString(info));
        }

        void ILogger.Warning(string warn)
        {
            UISync.Execute(() => logView[3].Text += GestLogString(warn));
        }

    }
}
