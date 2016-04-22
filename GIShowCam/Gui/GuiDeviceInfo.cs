using System;
using System.Windows.Forms;
using Vlc.DotNet.Core;

namespace GIShowCam.Gui
{
    class GuiDeviceInfo : GuiBase
    {
        string strCommon = Environment.NewLine;

        public GuiDeviceInfo(GuiBase mainB,  Label lblDev) : base(mainB)
        {
            


            strCommon = "  Startup options:" + Environment.NewLine;

            for (int i = 0; i < VlcContext.StartupOptions.Options.Count; i++)
                strCommon += VlcContext.StartupOptions.Options[i] + Environment.NewLine;

            lblDev.Text = strCommon;
        }

        #region Device Info



        #endregion Device Info



    }
}
