﻿using GIShowCam.Utils;
using System;
using System.Windows.Forms;

namespace GIShowCam.Gui
{
    internal partial class GuiBase
    {
        private DateTime _logTimeLast, _logTimeNow;
        internal void Log(string s)
        {
            if (_logTimeLast == DateTime.MinValue)//connection start
            {
                _logTimeLast = DateTime.Now;

                UISync.Execute(() =>
                TextUpdate(form.txtDev,
                     Environment.NewLine +
                     string.Format("{0:00}:{1:00}:{2:00}.{3:000}          ---    Conexiune pornita   ---",
                    _logTimeLast.Hour, _logTimeLast.Minute, _logTimeLast.Second, _logTimeLast.Millisecond)
                    , true, true, false));
            }            

            _logTimeNow = DateTime.Now;
            UISync.Execute(() =>
            TextUpdate(form.txtDev,
                string.Format("{0:00}:{1:00}:{2:00}.{3:000} {4} a inceput in {5} ms {6}",
                    _logTimeLast.Hour, _logTimeLast.Minute, _logTimeLast.Second, _logTimeLast.Millisecond,s,
                    ((int)_logTimeNow.Subtract(_logTimeLast).TotalMilliseconds).ToString(), Environment.NewLine)
                    , true, false, true));
            
        }

        private void TextUpdate(Control ctrl, string s, bool add, bool logAppend, bool updateDateLog)
        {
            if (add)
            {
                if (logAppend)
                {
                    string ipTxt = "", sidTxt = "";
                    if (form.comboAddress.Text.Length > 3)
                    {
                        int ips = form.comboAddress.Text.IndexOf('/', 6), ipf = form.comboAddress.Text.IndexOf('/', 7);
                        ipTxt = form.comboAddress.Text.Substring(ips + 1, ipf - ips - 1) + sidTxt;
                        sidTxt = form.comboAddress.Text.Substring(ipf + 1, form.comboAddress.Text.Length - ipf - 1) + sidTxt;

                        ipTxt = "            " + ipTxt + Environment.NewLine;
                        sidTxt = "            " + sidTxt + Environment.NewLine;
                    }

                    s = s + Environment.NewLine + ipTxt + sidTxt;
                }

                if (ctrl is TextBoxBase) (ctrl as TextBoxBase).AppendText(s);
                else
                    ctrl.Text += s;
            }
            else
                ctrl.Text = s;

            if(updateDateLog) _logTimeLast = _logTimeNow;

            //DateTime dt = DateTime.Now;
            //textLog.AppendText(string.Format("{0:00}:{1:00}:{2:00}.{3:000} ",
            //dt.Hour, dt.Minute, dt.Second, dt.Millisecond) + sir + Environment.NewLine);
        }

        internal void RestartConnection()
        {
            _logTimeLast = DateTime.MinValue;
        }


    }
}
