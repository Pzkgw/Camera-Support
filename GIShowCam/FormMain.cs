using Declarations.Players;
using GIShowCam.Gui;
using GIShowCam.Info;
using System;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;

namespace GIShowCam
{
    public partial class FormMain : Form
    {
        //private readonly Dispatcher _dispatchDr;

        private GuiBase mainB;

        public FormMain()
        {
            InitializeComponent();

            //_dispatchDr = Dispatcher.CurrentDispatcher;

            mainB = new GuiBase(this);

            if (SessionInfo.FullVideo)
            {
                mainB.VideoInit(false, true);
            }
            else
            {
                mainB.InitGuiControls();
                mainB.InitGuiDeviceInfo();
                mainB.InitGuiRecord();

                mainB.VideoInit(false, false);
            }

            mainB.DeviceTextBoxesUpdate(false);
            mainB.AddFormEvents();

            panelVlc.SendToBack();
            FormClosing += FormMain_FormClosing;
            

            MouseDown += FormMain_MouseDown;
        }

        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            if(panelVlc.Bounds.Contains(e.Location))
            {
                MessageBox.Show("Click in Vlc panel !");
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainB.CleanUp();
            base.Dispose();
        }


        /*
        internal void WaitForVlc(int msTimeout)
        {
            _dispatchDr.BeginInvoke(DispatcherPriority.Normal,
                new Action(delegate ()
                {
                    Thread.Sleep(1000);
                }));
        }



        internal void Test(string v)
        {
            InvokeGuiThread(new textUpdateDelegate(TextUpdate), lblAdd, v, false, false);
        }*/


        /*
        private void InvokeGuiThread(Delegate method, params object[] args)
        {
            _dispatchDr.BeginInvoke(method, args);//Invoke(method, args)  DispatcherPriority priority
            //BeginInvoke(method, args);
        }*/

    }
}
