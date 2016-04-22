using System;
using System.Windows.Forms;
using Vlc.DotNet.Core;

namespace GIShowCam.Gui
{
    class GuiDeviceInfo : GuiBase
    {
        Label lblDev;
        string strCommon = Environment.NewLine;

        public GuiDeviceInfo(GuiBase mainB,  Label lblDev) : base(mainB)
        {
            this.lblDev = lblDev;

            VlcStartupOptions opt = VlcContext.StartupOptions;
            strCommon = "  Startup options:" + Environment.NewLine;

            for (int i = 0; i < opt.Options.Count; i += 2)
            {
                strCommon += opt.Options[i] +
                    ((i < opt.Options.Count - 1) ? new string(' ', 32 - opt.Options[i].Length) + opt.Options[i + 1] : "") +
                    Environment.NewLine;
            }

            FilDevInfo();
            
        }

        private void FilDevInfo()
        {
            string devInfo;
            devInfo = vlc.Media.MRL;




            lblDev.Text = devInfo+ strCommon;
        }

        #region Device Info



        #endregion Device Info



    }
}
