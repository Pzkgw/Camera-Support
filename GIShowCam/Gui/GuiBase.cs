using GIShowCam.Info;
using System.Linq;
using System.Windows.Forms;
using Vlc.DotNet.Forms;
using Vlc.DotNet.Core;
using Vlc.DotNet.Core.Medias;

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
            form = g.form;
            vlc = g.vlc;
        }

        #region Camera Video

        protected void VideoPlay()
        {
            if (vlc.Media != null) vlc.Media.Dispose();

            if (SessionInfo.host.Count(s => s == '.') > 2)
            {
                string path = SessionInfo.host;
                
                if(((path[5]=='/')||(path[6]=='/'))&& SessionInfo.user.Length>0)// http:// sau rtsp://
                {
                    path = path.Insert(7, (SessionInfo.user + ":" + SessionInfo.pass + "@"));
                }

                //vlc rtsp://10.10.10.78/axis-media/media.amp --rtsp-user=root --rtsp-pwd=cavi123,.
                LocationMedia media = new LocationMedia(path);
                media.AddOption("-vvv");//posibil optional

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

            VlcContext.CloseAll();
        }
        


    }
}
