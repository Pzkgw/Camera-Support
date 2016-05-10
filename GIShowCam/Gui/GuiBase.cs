﻿using GIShowCam.Info;
using System;
using System.Windows.Forms;

namespace GIShowCam.Gui
{
    internal partial class GuiBase
    {
        private SessionInfo info;
        private FormMain form;

        internal GuiBase(FormMain formBase)
        {
            UISync.Init(formBase);
            info = new SessionInfo();

            _logTimeLast = DateTime.MinValue;
            form = formBase;

            vlcInit();

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
