
using GIShowCam.Vlc_override;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Vlc.DotNet.Core;

// -- Connect to camera --
namespace GIShowCam.Gui
{
    internal partial class GuiBase
    {

        private GIVlcControl vlc;

        private Point _vlcTop;
        private Size _vlcSize;

        internal void VideoInit(bool fullView, bool allowResize, bool allowVlcMediaReinit)
        {
            form.isOn = false;
            /*
            if (vlc == null)
            {
                _vlcTop = form.panelVlc.Location;
                _vlcSize = form.panelVlc.Size;
            }*/

            if (vlc != null)
            {
                vlc.Pause();
            }


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

            if (allowVlcMediaReinit)
            {
                form.RestartConnection();

                if (vlc == null)
                {
                    //opt.ScreenSaverEnabled = false;

                    vlc = new GIVlcControl();
                    //vlc.Name = "vlc";
                    vlc.TabStop = false;
                    vlc.Enabled = false;
                    vlc.BackColor = Color.Empty;
                    vlc.ImeMode = ImeMode.NoControl;
                    vlc.Dock = DockStyle.Fill;

                    vlc.Parent = form.panelVlc;
                    vlc.initEndNeeded = true;

                    AddVlcEvents();
                }
                else
                {
                    vlc.Stop(false);
                }

                string path = info.host;

                if (path.Count(s => s == '.') > 2)
                {

                    if (!string.IsNullOrEmpty(info.user) && !string.IsNullOrEmpty(info.password) && ((path[5] == '/') || (path[6] == '/')))// http:// sau rtsp://
                    {
                        path = path.Insert(7, (info.user + ":" + info.password + "@"));
                    }

                    //vlc http://admin:1qaz@WSX@192.168.0.92/streaming/channels/2/httppreview --aspect-ratio=16:9
                }

                if (vlc.initEndNeeded)
                {
                    vlc.VlcLibDirectory = new DirectoryInfo(GetVlcLibLocation());
                    vlc.EndInit();
                    vlc.initEndNeeded = false;
                }

                
                vlc.SetMedia(path, GetVlcOptions());
            }
            form.isOn = true;
        }

        /// <summary>
        /// Event chemat dupa ce o noua camera e conectata (MediaChanged)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void Vlc_MediaChanged(object sender, VlcMediaPlayerMediaChangedEventArgs e)
        {
            info.SelectCamera(); // comboBox change cheama al doilea select aici 

            info.cam.data.PropertyChanged += Data_PropertyChanged;
            vlc.GetCurrentMedia().StateChanged += GuiBase_StateChanged;

            vlc.Play();
        }

        private void ComboAddress_SelectionChangeCommitted(object sender, EventArgs e)
        {
            info.SelectCamera(form.comboAddress.SelectedIndex);
            
            form.txtDevUser.Text = info.user;
            form.txtDevPass.Text = info.password;
            form.comboAddress.Text = info.host;

            BtnDevConnect_Click(null, null);
        }

        private void BtnDevConnect_Click(object sender, EventArgs e)
        {
            VideoInit(false, false, true);
        }

    }
}
