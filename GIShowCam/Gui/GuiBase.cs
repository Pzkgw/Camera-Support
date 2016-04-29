using GIShowCam.Info;
using System.Linq;
using System.Windows.Forms;
using Vlc.DotNet.Forms;
using Vlc.DotNet.Core;
using System.Drawing;
using System;
using System.IO;

namespace GIShowCam.Gui
{
    internal partial class GuiBase
    {
        private FormMain form;

        private Point _vlcTop;
        private Size _vlcSize;

        public GuiBase(FormMain formBase)
        {
            form = formBase;
            InitVlc();
            vlc.Parent = form.panelVlc;
        }

        private void setVlcLibLocation()
        {
            //vlc.VlcLibDirectoryNeeded += Vlc_VlcLibDirectoryNeeded;

            string aP;
            if (Environment.Is64BitOperatingSystem)
                aP = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "VideoLAN\\VLC");
            else
                aP = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "VideoLAN\\VLC");

            /*else if (!File.Exists(Path.Combine(aP, "libvlc.dll"))
                           {
                           Using fbdDialog As New FolderBrowserDialog()
                           fbdDialog.Description = "Select VLC Path"
                           fbdDialog.SelectedPath = Path.Combine(aP, "VideoLAN\VLC")

                           If fbdDialog.ShowDialog() = DialogResult.OK Then
                           e.VlcLibDirectory = New DirectoryInfo(fbdDialog.SelectedPath)
                       }

            e.VlcLibDirectory = new DirectoryInfo(aP);*/

            vlc.VlcLibDirectory = new DirectoryInfo(aP);

            vlc.EndInit();
        }

        internal void FullVideo(bool on, bool startInit)
        {
            if (on)
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

            if (startInit)
            {
                VideoPlayInit();
            }
        }

        public GuiBase(GuiBase g)
        {
            form = g.form;
            vlc = g.vlc;
            info = g.info;
        }

        #region Camera Video

        protected void VideoPlayInit()
        {
            if (vlc != null)
            {

                if (vlc.IsPlaying)
                {
                    form.Restart();
                }

                if (vlc.GetCurrentMedia() != null)
                {
                    vlc.GetCurrentMedia().Dispose();
                    vlc.Stop();
                }

                if (info.host.Count(s => s == '.') > 2)
                {
                    string path = info.host;

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



                    vlc.SetMedia(path);
                }
                else
                {
                    vlc.SetMedia(info.host);
                }

            }
        }


        #endregion Camera Video





        internal void CleanUp()
        {
            form.isOn = false;// avoid event send
            if (vlc.IsPlaying) vlc.Stop();
            //if (vlc.Media != null) vlc.Media.Dispose();
            //if (vlc != null) vlc.Dispose();

            //VlcContext.CloseAll();
            vlc.Dispose();
        }



    }
}
