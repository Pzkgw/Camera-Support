using GIShowCam.Info;
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
