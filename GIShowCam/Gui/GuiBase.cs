﻿using GIShowCam.Info;
using System.Windows.Forms;
using System.Drawing;

namespace GIShowCam.Gui
{
    internal partial class GuiBase
    {
        private SessionInfo info;
        private FormMain form;

        private Point _vlcTop;
        private Size _vlcSize;

        public GuiBase(FormMain formBase)
        {
            info = new SessionInfo();
            form = formBase;

            InitVlc();
            vlc.Parent = form.panelVlc;
        }


        internal void VideoInit(bool fullView, bool allowResize)
        {
            if (allowResize)
                if (fullView)
                {
                    _vlcTop = form.panelVlc.Location;
                    _vlcSize = form.panelVlc.Size;
                    form.panelVlc.Location = new Point(0, 0);
                    form.panelVlc.Size = new Size(form.Width, form.Height);
                    form.panelVlc.Dock = DockStyle.Fill;
                    form.panelVlc.BringToFront();
                }
                else
                {
                    form.panelVlc.Location = _vlcTop;
                    form.panelVlc.Size = _vlcSize;
                    form.panelVlc.Dock = DockStyle.None;
                    //form.panelVlc.SendToBack();
                }

            VideoPlayInit();
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
