using System;
using Vlc.DotNet.Core;

namespace GIShowCam.Gui
{
    internal partial class GuiBase
    {
        string strCommon = Environment.NewLine, strCommonLine = "";

        internal void InitGuiDeviceInfo()
        {

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




            form.lblDev.Text = devInfo + strCommon;
        }

        #region real time Device Info

        /// <summary>
        /// Event handler for "VlcControl.PositionChanged" event. 
        /// Updates the label containing the playback position. 
        /// </summary>
        /// <param name="sender">Event sending. </param>
        /// <param name="e">Event arguments, containing the current position. </param>
        private void Vlc_PositionChanged(object sender, VlcMediaPlayerPositionChangedEventArgs e)
        {
            //form.ControlTextUpdate(lblVlcNotifications, "Pozitie(doar pentru video local) : " + (e.Data * 100).ToString("000") + " %");
            //form.ControlTextUpdate(lblVlcNotifications, "FPS: " + vlc.FPS);

            if (vlc != null && vlc.GetCurrentMedia() != null)
            {
                form.ControlTextUpdate(form.lblVlcNotify,
                    "DecodedVideo: " + vlc.GetCurrentMedia().Statistics.DecodedVideo +
                    "  InputBitrate: " + vlc.GetCurrentMedia().Statistics.InputBitrate +
                    "  DemuxBitrate: " + vlc.GetCurrentMedia().Statistics.DemuxBitrate +
                    "  DisplayedPictures: " + vlc.GetCurrentMedia().Statistics.DisplayedPictures +
                    "  LostPictures: " + vlc.GetCurrentMedia().Statistics.LostPictures);

                //form.Log("Poze = " + vlc.GetCurrentMedia().Statistics.DisplayedPictures);

                if (!info.cam.data.IsVideoComplete &&
                    info.cam.data.imgCount < (ulong)vlc.GetCurrentMedia().Statistics.DisplayedPictures)
                {
                    info.cam.data.imgCount =
                       (ulong)vlc.GetCurrentMedia().Statistics.DisplayedPictures;
                    info.cam.data.IsVideoComplete = true;
                }
                //form.Log("Poze = " + vlc.GetCurrentMedia().Statistics.DisplayedPictures);
            }
        }


        #endregion real time Device Info



    }
}
