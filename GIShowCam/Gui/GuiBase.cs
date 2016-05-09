using GIShowCam.Info;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GIShowCam.Gui
{
    internal partial class GuiBase
    {
        private SessionInfo info;
        private FormMain form;

        public GuiBase(FormMain formBase)
        {
            info = new SessionInfo();
            form = formBase;

            form.panelVlc.Click += PanelVlc_Click;
        }

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


        }



    }
}
