using System;
using System.Windows.Forms;

namespace GIShowCam.Gui
{
    internal partial class GuiBase
    {
        Label lblDev;
        string strCommon = Environment.NewLine, strCommonLine = "";

        internal void InitGuiDeviceInfo(GuiBase mainB, Label lblDev)
        {
            this.lblDev = lblDev;
            /*
            VlcStartupOptions opt = VlcContext.StartupOptions;
            strCommon = Environment.NewLine + "  Startup options:" + Environment.NewLine + Environment.NewLine;

            int lengthStr;
            for (int i = 0; i < opt.Options.Count; i++)
            {
                //strCommon += opt.Options[i].Substring(2, opt.Options[i].Length - 2) +
                //  ((i < opt.Options.Count - 1) ? new string(' ', 32 - opt.Options[i].Length) + opt.Options[i + 1].Substring(2, opt.Options[i + 1].Length - 2) : "") +
                //  Environment.NewLine;

                lengthStr = opt.Options[i].Length;
                if((strCommonLine.Length+lengthStr) > (lblDev.Parent.Width / 5))
                {
                    strCommon += strCommonLine + Environment.NewLine;
                    strCommonLine = "";
                }

                strCommonLine += ((i + 1).ToString() + ". " +
                    (opt.Options[i].StartsWith("-") ? opt.Options[i].Substring(2, lengthStr - 2) : "void")) + new string(' ', 15);
                // + ((i == opt.Options.Count - 1) ? "" : " | ")
            }
            */
            strCommon += strCommonLine;

            FilDevInfo();

        }

        private void FilDevInfo()
        {
            string devInfo = "";
            //devInfo = vlc.Media.Metadatas.Title + Environment.NewLine;




            lblDev.Text = devInfo + strCommon;
        }

        #region Device Info



        #endregion Device Info



    }
}
