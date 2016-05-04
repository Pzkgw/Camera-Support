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
                MessageBox.Show("  Bravo !  ");
            }


        }

        #region CleanUp

        internal void CleanUp()
        {
            form.isOn = false;// avoid event send
            if (vlc.IsPlaying) vlc.Stop();
            //if (vlc.Media != null) vlc.Media.Dispose();
            //if (vlc != null) vlc.Dispose();

            //VlcContext.CloseAll();
            vlc.Dispose();
        }

        #endregion CleanUp

    }
}
