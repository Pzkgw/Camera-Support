using Declarations;
using Declarations.Events;
using GIShowCam.Utils;
using System;


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
            //string devInfo = "";
            //devInfo = vlc.Media.Metadatas.Title + Environment.NewLine;




            //form.txtDev.Text = devInfo + strCommon;
        }

        #region real time Device Info


        //UISync.Execute(() => trackBar1.Value = (int)(e.NewPosition * 100));


        /// <summary>
        /// Event handler for "VlcControl.PositionChanged" event. 
        /// Updates the label containing the playback position. 
        /// </summary>
        /// <param name="sender">Event sending. </param>
        /// <param name="e">Event arguments, containing the current position. </param>
        void Events_PlayerPositionChanged(object sender, MediaPlayerPositionChanged e)
        {
            //form.ControlTextUpdate(lblVlcNotifications, "Pozitie(doar pentru video local) : " + (e.Data * 100).ToString("000") + " %");
            //form.ControlTextUpdate(lblVlcNotifications, "FPS: " + vlc.FPS);
            if (m_media != null && m_player != null && m_player.IsPlaying)
            {

                UISync.Execute(() => TextUpdate(form.lblVlcNotify,
                        "Timp de functionare: " + m_player.Time / 60000 + " minute si " +
                        (m_player.Time / 1000) % 60 + " secunde " +
                        ", DecodedVideo: " + m_media.Statistics.DecodedVideo +
                        ", InputBitrate: " + m_media.Statistics.InputBitrate +
                        ", DemuxBitrate: " + m_media.Statistics.DemuxBitrate +
                        ", DisplayedPictures: " + m_media.Statistics.DisplayedPictures +
                        ", LostPictures: " + m_media.Statistics.LostPictures
                        , false, false, false));

                //form.Log("Poze = " + vlc.GetCurrentMedia().Statistics.DisplayedPictures);

                if (!info.cam.data.IsVideoComplete &&
                    info.cam.data.imgCount < m_media.Statistics.DisplayedPictures)
                {
                    info.cam.data.imgCount = m_media.Statistics.DisplayedPictures;
                    info.cam.data.IsVideoComplete = true;
                    SetBtnsVisibilityOnPlay(true);

                }
                //form.Log("Poze = " + media.Statistics.DisplayedPictures);
                UISync.Execute(() => UpdateEventsLabel());



            }
        }

        private void UpdateEventsLabel()
        {
            if (lblEventsShowCount > 0)
            {
                --lblEventsShowCount;
                if (lblEventsShowCount == 0)
                {
                    form.lblEvent.Text = null;
                }
            }
        }


        #endregion real time Device Info



    }
}
