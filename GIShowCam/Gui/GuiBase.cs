using GIShowCam.Info;
using GIShowCam.Utils;
using System;

namespace GIShowCam.Gui
{
    internal partial class GuiBase
    {
        private SessionInfo info;
        private FormMain form;
        

        internal GuiBase(FormMain formBase)
        {
            _logTimeLast = DateTime.MinValue;
            form = formBase;

            SessionInfo.logger = new CLogger(form.txtLVDebug, form.txtLVErrors, form.txtLVInfo, form.txtLVWarnings);
            info = new SessionInfo();

            UISync.Init(formBase);
            

            DiscoverDevices();
            

            //form.panelVlc.BringToFront();
            //form.panelVlc.Click += PanelVlc_Click;

        }

        private void DiscoverDevices()
        {
            Discovery discovery;

            discovery = new Discovery(m_factory);

            discovery.CleanUp();
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
