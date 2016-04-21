using GIShowCam;
using GIShowCam.Info;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Forms;
using Vlc.DotNet.Core;
using Vlc.DotNet.Core.Medias;
using System.Windows.Threading;

namespace GIShowCam.Gui
{
    class GuiBase 
    {
        protected FormMain form;

        protected VlcControl vlc;


        public GuiBase(FormMain formBase, Panel panelVlc)
        {
            this.form = formBase;

            vlc = new VlcControl();
            vlc.Dock = DockStyle.Fill;
            vlc.Enabled = false;
            //vlc.ImeMode = System.Windows.Forms.ImeMode.NoControl;

            vlc.Parent = panelVlc;
        }

        public GuiBase(GuiBase g)
        {
            this.form = g.form;
            this.vlc = g.vlc;
        }

        #region Camera Video

        protected void VideoPlay()
        {
            if (vlc.Media != null) vlc.Media.Dispose();

            if (SessionInfo.host.Count(s => s == '.') > 2)
            {
                string path = SessionInfo.host, util = SessionInfo.user + ":" + SessionInfo.pass + "@";
                
                if(((path[5]=='/')||(path[6]=='/'))&& SessionInfo.user.Length>0)// http sau "rtsp://"
                {
                    path = path.Insert(7, util);
                }

                LocationMedia media = new LocationMedia(path);
                media.AddOption("vvv");//posibil optional

                vlc.Media = media;
                

            }
            else
            {
                vlc.Media = new PathMedia(SessionInfo.host);
            }            

            vlc.Play();
        }


        #endregion Camera Video





        internal void CleanUp()
        {
            if (vlc.IsPlaying) vlc.Stop();
            if (vlc.Media != null) vlc.Media.Dispose();
            if (vlc != null) vlc.Dispose();
        }
        


    }
}
