using GIShowCam.Info;
using System.Linq;
using System.Windows.Forms;
using Vlc.DotNet.Forms;
using Vlc.DotNet.Core;
using Vlc.DotNet.Core.Medias;
using System.Drawing;

namespace GIShowCam.Gui
{
    class GuiBase 
    {
        protected FormMain form;

        protected VlcControl vlc;

        protected SessionInfo info;


        public GuiBase(FormMain formBase, Panel panelVlc)
        {
            
            this.form = formBase;
            info = new SessionInfo();

            //VlcContext.StartupOptions.AddOption("--width=" + panelVlc.Width);
            //VlcContext.StartupOptions.AddOption("--height=" + panelVlc.Height);
            //VlcContext.StartupOptions.AddOption("--aspect-ratio=1:9");
            //VlcContext.StartupOptions.AddOption("--autocrop");--crop-geometry "180 x 120 + 0 + 0"
            //VlcContext.StartupOptions.AddOption("--crop-geometry \"" + panelVlc.Width + "x" + panelVlc.Height + " + 0 + 0\"");--aspect-ratio=16:9

            //vlc http://admin:1qaz@WSX@192.168.0.92/streaming/channels/2/httppreview --aspect-ratio=16:9

            vlc = new VlcControl();
            vlc.Name = "vlc";
            vlc.Parent = panelVlc;

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

                vlc.Stop();
                if (vlc.Media != null) vlc.Media.Dispose();

                if (info.host.Count(s => s == '.') > 2)
                {
                    string path = info.host;

                    if (!string.IsNullOrEmpty(info.user) && !string.IsNullOrEmpty(info.password) && ((path[5] == '/') || (path[6] == '/')))// http:// sau rtsp://
                    {
                        path = path.Insert(7, (info.user + ":" + info.password + "@"));
                    }

                    //vlc rtsp://10.10.10.78/axis-media/media.amp --rtsp-user=root --rtsp-pwd=cavi123,.
                    LocationMedia media = new LocationMedia(path);
                    media.AddOption("no-snapshot-preview");
                    //media.AddOption("-vvv");//optional : "Verbose verbose verbose". Verbose output
                    //media.AddOption("–-aspect-ratio=4:3");
                    //media.AddOption("--grayscale");

                    

                    vlc.Media = media;
                }
                else
                {
                    vlc.Media = new PathMedia(info.host);
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

            VlcContext.CloseAll();
        }
        


    }
}
