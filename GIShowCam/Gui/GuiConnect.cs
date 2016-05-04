
using GIShowCam.Vlc_override;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

// -- Connect to camera --
namespace GIShowCam.Gui
{
    internal partial class GuiBase
    {

        private GIVlcControl vlc;

        private void InitVlcStart()
        {
            //opt = VlcContext.StartupOptions;

            //opt.ScreenSaverEnabled = false;

            //SetDirectory();

            //if (SessionInfo.debug) EnableLogConsole();

            vlc = new GIVlcControl();
            vlc.Name = "vlc";
            vlc.TabStop = false;
            vlc.Enabled = false;
            vlc.ImeMode = ImeMode.NoControl;
            vlc.Dock = DockStyle.Fill;
            vlc.BackColor = Color.Empty;
            //vlc.Rate = 0.0f;
            //vlc.Location = new Point(0,0);
            //vlc.Size = new Size(panelVlc.Width, panelVlc.Height);
            //vlc.Width = panelVlc.Width;
            //vlc.Height = panelVlc.Height;
            //vlc.SetBounds(0, 0, panelVlc.Width, panelVlc.Height);
        }

        private void InitVlcEnd()
        {
            vlc.VlcLibDirectory = new DirectoryInfo(GetVlcLibLocation());
            vlc.VlcMediaplayerOptions = GetVlcOptions();
            vlc.EndInit();
        }


        private void ComboAddress_SelectionChangeCommitted(object sender, EventArgs e)
        {
            info.Select(form.comboAddress.SelectedIndex);
            info.cam.data.PropertyChanged += Data_PropertyChanged;
            form.txtDevUser.Text = info.user;
            form.txtDevPass.Text = info.password;
            form.comboAddress.Text = info.host;

            BtnDevConnect_Click(null, null);
        }

        private void BtnDevConnect_Click(object sender, EventArgs e)
        {
            VideoInit(false, false);

            if (vlc != null && vlc.GetCurrentMedia() != null)
            {
                info.cam.data.IsStarted = true;
                info.cam.data.Start();

                SignEvents();
                vlc.Play();
            }
            else
            {
                MessageBox.Show("Eroare la conexiune");
            }
        }

        protected void VideoPlayInit()
        {

            form.Restart();

            if (vlc == null)
            {
                InitVlcStart();
                vlc.Parent = form.panelVlc;
                vlc.initEndNeeded = true;
            }
            else
            {

                // if (vlc.GetCurrentMedia() != null){    vlc.GetCurrentMedia().Dispose();    vlc.Stop();    vlc.Unregister(); } 
                //vlc.Dispose();
                //vlc = null;
                vlc.Stop();
            }

            string path = info.host;

            if (path.Count(s => s == '.') > 2)
            {

                if (!string.IsNullOrEmpty(info.user) && !string.IsNullOrEmpty(info.password) && ((path[5] == '/') || (path[6] == '/')))// http:// sau rtsp://
                {
                    path = path.Insert(7, (info.user + ":" + info.password + "@"));
                }

                //vlc rtsp://10.10.10.78/axis-media/media.amp --rtsp-user=root --rtsp-pwd=cavi123,.
                //LocationMedia media = new LocationMedia(path);
                //media.AddOption("no-snapshot-preview");
                //media.AddOption("-vvv");//optional : "Verbose verbose verbose". Verbose output
                //media.AddOption("–-aspect-ratio=4:3");
                //media.AddOption("--grayscale");

                //VlcContext.StartupOptions.AddOption("--width=" + panelVlc.Width);
                //VlcContext.StartupOptions.AddOption("--height=" + panelVlc.Height);
                //VlcContext.StartupOptions.AddOption("--aspect-ratio=1:9");
                //VlcContext.StartupOptions.AddOption("--autocrop");--crop-geometry "180 x 120 + 0 + 0"
                //VlcContext.StartupOptions.AddOption("--crop-geometry \"" + panelVlc.Width + "x" + panelVlc.Height + " + 0 + 0\"");--aspect-ratio=16:9

                //vlc http://admin:1qaz@WSX@192.168.0.92/streaming/channels/2/httppreview --aspect-ratio=16:9

                //vlc.GetCurrentMedia().ParseAsync();
            }

            if (vlc.initEndNeeded)
            {
                InitVlcEnd();
                vlc.initEndNeeded = false;
            }
            vlc.SetMedia(path);

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


    }
}
