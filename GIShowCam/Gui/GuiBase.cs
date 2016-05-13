using GIShowCam.Info;
using GIShowCam.Utils;
using System;
using System.Windows.Forms;

namespace GIShowCam.Gui
{
    internal partial class GuiBase
    {
        private SessionInfo info;
        private FormMain form;
        private CLogger logger;

        internal GuiBase(FormMain formBase)
        {

            _logTimeLast = DateTime.MinValue;
            form = formBase;

            logger = new CLogger(form.txtLVDebug, form.txtLVErrors, form.txtLVInfo, form.txtLVWarnings);
            info = new SessionInfo();

            UISync.Init(formBase);
            vlcInit(logger);
            
            //form.panelVlc.BringToFront();
            //form.panelVlc.Click += PanelVlc_Click;

        }
        /*
        private void PanelVlc_Click(object sender, EventArgs e)
        {
            if (form.chkFullVid.Checked)
            {
                form.chkFullVid.Checked = false;
            }
            else
            {
                if (SessionInfo.showMessageBoxes) MessageBox.Show("  Bravo !  ");
            }


        }*/



    }
}
