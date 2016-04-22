using GIShowCam.Gui;
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

namespace GIShowCam
{
    public partial class FormMain : Form
    {
        private GuiBase mainB;
        private readonly Dispatcher _dispatchDr;


        public FormMain()
        {
            InitializeComponent();

            _dispatchDr = Dispatcher.CurrentDispatcher;

            mainB = new GuiBase(this, panelVlc);

            new GuiControls(mainB, btnDevConnect, txtDevUrl, txtDevUser, txtDevPass,
                btnPlay, btnSnapshot, btnRecord, lblVlcNotify);
            new GuiDeviceInfo(mainB, lblDev);

            FormClosing += FormMain_FormClosing;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainB.CleanUp();
        }


        #region GUI Events

        internal void ControlTextUpdate(Control ctrl, string s)
        {
            InvokeGuiThread(new textUpdateDelegate(TextUpdate), ctrl, s);
        }

        internal void ControlShow(Control ctrl, bool on)
        {
            InvokeGuiThread(new delegateEnableControl(ControlEnable), ctrl, on);
        }

        #endregion GUI Events


        #region GUI Events Main

        private void InvokeGuiThread(Delegate method, params object[] args)
        {
            _dispatchDr.BeginInvoke(method, args);//Invoke(method, args)  DispatcherPriority priority
            //BeginInvoke(method, args);
        }

        private delegate void textUpdateDelegate(Control ctrl, string sir);
        private void TextUpdate(Control ctrl, string sir)
        {

            ctrl.Text = sir;

            //DateTime dt = DateTime.Now;
            //textLog.AppendText(string.Format("{0:00}:{1:00}:{2:00}.{3:000} ", dt.Hour, dt.Minute, dt.Second, dt.Millisecond) + sir + Environment.NewLine);
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
