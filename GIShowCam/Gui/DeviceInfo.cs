using Declarations.Events;
using GIShowCam.Utils;
using System;

namespace GIShowCam.Gui
{
    internal partial class GuiBase
    {
        //private string _strCommon = Environment.NewLine;, _strCommonLine = "";

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
            //_strCommon += _strCommonLine;

            //FilDevInfo();

        }
        /*
        private void FilDevInfo()
        {
            //string devInfo = "";
            //devInfo = vlc.Media.Metadatas.Title + Environment.NewLine;




            //form.txtDev.Text = devInfo + strCommon;
        }*/

        #region real time Device Info


        //UISync.Execute(() => trackBar1.Value = (int)(e.NewPosition * 100));


        /// <summary>
        /// Event handler for "VlcControl.PositionChanged" event. 
        /// Updates the label containing the playback position. 
        /// </summary>
        /// <param name="sender">Event sending. </param>
        /// <param name="e">Event arguments, containing the current position. </param>
        private void Events_PlayerPositionChanged(object sender, MediaPlayerPositionChanged e)
        {
            //form.ControlTextUpdate(lblVlcNotifications, "Pozitie(doar pentru video local) : " + (e.Data * 100).ToString("000") + " %");
            //form.ControlTextUpdate(lblVlcNotifications, "FPS: " + vlc.FPS);

            if (_mPlayer == null || !_mPlayer.IsPlaying) return;

            _form.BeginInvoke((Action)(() => StatsUpdate()));
        }

        private void StatsUpdate()
        {
            /*
            TextUpdate(_form.lblVlcNotify,
    @"Timp de functionare: " + _mPlayer.Time / 60000 + @" minute si " +
    (_mPlayer.Time / 1000) % 60 + @" secunde " +
    @", DecodedVideo: " + _mPlayer.CurrentMedia.Statistics.DecodedVideo +
    @", InputBitrate: " + _mPlayer.CurrentMedia.Statistics.InputBitrate +
    @", DemuxBitrate: " + _mPlayer.CurrentMedia.Statistics.DemuxBitrate +
    @", DisplayedPictures: " + _mPlayer.CurrentMedia.Statistics.DisplayedPictures +
    @", LostPictures: " + _mPlayer.CurrentMedia.Statistics.LostPictures
    , false, false, false);

            //form.Log("Poze = " + vlc.GetCurrentMedia().Statistics.DisplayedPictures);

            if (!_info.Cam.Data.IsVideoComplete &&
                _info.Cam.Data.ImgCount < _mPlayer.CurrentMedia.Statistics.DisplayedPictures)
            {
                _info.Cam.Data.ImgCount = _mPlayer.CurrentMedia.Statistics.DisplayedPictures;
                _info.Cam.Data.IsVideoComplete = true;
                SetBtnsVisibilityOnPlay(true);
            }
            //form.Log("Poze = " + media.Statistics.DisplayedPictures);
            UpdateEventsLabel();
            */
        }

        private void UpdateEventsLabel()
        {
            if (_lblEventsShowCount < 1) return;

            --_lblEventsShowCount;
            if (_lblEventsShowCount == 0)
            {
                _form.lblEvent.Text = null;
            }
        }


        #endregion real time Device Info



    }
}
