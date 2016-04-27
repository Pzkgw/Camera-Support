using GIShowCam.Gui;
using GIShowCam.Info;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using Vlc.DotNet.Core;

namespace GIShowCam
{
    public partial class FormMain : Form
    {
        public bool isOn = true;

        private readonly Dispatcher _dispatchDr;

        private GuiBase mainB;
        private DateTime _logTimeLast, _logTimeNow;
        

        public FormMain()
        {
            InitializeComponent();

            _dispatchDr = Dispatcher.CurrentDispatcher;
            //_logDispatch = new Dispatcher();
            _logTimeLast = DateTime.MinValue;

            VlcContext.CloseAll();
            VlcContext.Initialize();

            mainB = new GuiBase(this, panelVlc);
            if (!SessionInfo.fullVideo)
            {
                new GuiControls(mainB, btnDevConnect, comboAddress,
                    txtDevUser, txtDevPass, textBoxWidthF, textBoxHeightF,
                    btnPlay, chkPlayLoop, chkFullVid, lblVlcNotify);
                new GuiDeviceInfo(mainB, lblDev);
                new GuiRecord(mainB, btnSnapshot, btnRecord);
            }
            else
            {
                mainB.FullVideo(true, true);
            }

            FormClosing += FormMain_FormClosing;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainB.CleanUp();
        }
        internal void Restart()
        {
            _logTimeLast = DateTime.MinValue;
        }


        #region GUI Events

        internal void ControlTextUpdate(Control ctrl, string s)
        {
            InvokeGuiThread(new textUpdateDelegate(TextUpdate), ctrl, s, false, false);
        }

        internal void Log(string s)
        {
            if(_logTimeLast == DateTime.MinValue)//connection start
            {
                _logTimeLast = DateTime.Now;

                InvokeGuiThread(new textUpdateDelegate(TextUpdate), txtDev,
                     Environment.NewLine +
                     " Start conexiune la: " + string.Format("{0:00}:{1:00}:{2:00}.{3:000} ",
                    _logTimeLast.Hour, _logTimeLast.Minute, _logTimeLast.Second, _logTimeLast.Millisecond)
                    , true, true);
            }

            {
                _logTimeNow = DateTime.Now;
                InvokeGuiThread(new textUpdateDelegate(TextUpdate), txtDev,
                    ((int)_logTimeNow.Subtract(_logTimeLast).TotalMilliseconds).ToString() + " ms " + s + Environment.NewLine, true, false);
                _logTimeLast = _logTimeNow;
            }


        }

        internal void ControlShow(Control ctrl, bool on)
        {
            InvokeGuiThread(new delegateEnableControl(ControlEnable), ctrl, on);
        }

        #endregion GUI Events


        #region GUI Events Main

        private void InvokeGuiThread(Delegate method, params object[] args)
        {
            if (isOn)
                _dispatchDr.BeginInvoke(method, args);//Invoke(method, args)  DispatcherPriority priority
            //BeginInvoke(method, args);
        }

        private delegate void textUpdateDelegate(Control ctrl, string s, bool add, bool logAppend);
        private void TextUpdate(Control ctrl, string s, bool add, bool logAppend)
        {
            if (add)
            {
                if(logAppend)
                {
                    string ipTxt = "", sidTxt = "";
                    if (comboAddress.Text.Length > 3)
                    {
                        int ips = comboAddress.Text.IndexOf('/', 6), ipf = comboAddress.Text.IndexOf('/', 7);
                        ipTxt = comboAddress.Text.Substring(ips + 1, ipf - ips - 1) + sidTxt;
                        sidTxt = comboAddress.Text.Substring(ipf + 1, comboAddress.Text.Length - ipf - 1) + sidTxt;

                        ipTxt = " Adresa: " + ipTxt + Environment.NewLine;
                        sidTxt = " Camera: " + sidTxt + Environment.NewLine;
                    }

                    s = s + Environment.NewLine + ipTxt + sidTxt;
                }

                if (ctrl is TextBoxBase) (ctrl as TextBoxBase).AppendText(s);
                else
                    ctrl.Text += s;
            }
            else
                ctrl.Text = s;

            //DateTime dt = DateTime.Now;
            //textLog.AppendText(string.Format("{0:00}:{1:00}:{2:00}.{3:000} ",
            //dt.Hour, dt.Minute, dt.Second, dt.Millisecond) + sir + Environment.NewLine);
        }

        private delegate void delegateEnableControl(Control ctrl, bool enabled);
        private void ControlEnable(Control ctrl, bool enabled)
        {
            ctrl.Enabled = enabled;
            ctrl.Visible = enabled;
        }




        #endregion GUI Events Main
    }
}
