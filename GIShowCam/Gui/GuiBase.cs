using GIShowCam.Info;
using GIShowCam.Utils;
using System;

namespace GIShowCam.Gui
{
    internal partial class GuiBase
    {
        private readonly SessionInfo _info;
        private readonly FormMain _form;
        

        internal GuiBase(FormMain formBase)
        {
            _logTimeLast = DateTime.MinValue;
            _form = formBase;

            SessionInfo.Logger = new CLogger(_form.txtLVDebug, _form.txtLVErrors, _form.txtLVInfo, _form.txtLVWarnings);
            _info = new SessionInfo();

            UiSync.SetSyncObj(formBase);
            

            DiscoverDevices();
            

            //form.panelVlc.BringToFront();
            //form.panelVlc.Click += PanelVlc_Click;

        }

        private void DiscoverDevices()
        {
            Discovery discovery;

            discovery = new Discovery(_mFactory);

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
