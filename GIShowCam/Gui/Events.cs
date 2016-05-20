using Declarations;
using Declarations.Events;
using GIShowCam.Info;
using GIShowCam.Utils;
using System;
using System.Windows.Forms;

namespace GIShowCam.Gui
{
    internal partial class GuiBase
    {
        private DateTime _logTimeLast, _logTimeNow;


        /// <summary>
        /// Add\remove events for the media player
        /// </summary>
        /// <returns></returns>
        internal void RegisterPlayerEvents(bool on)
        {
            if (on)
            {
                m_player.Events.MediaChanged += new EventHandler<MediaPlayerMediaChanged>(Events_MediaChanged);
                m_player.Events.PlayerPositionChanged += new EventHandler<MediaPlayerPositionChanged>(Events_PlayerPositionChanged);
            }
            else
            {
                m_player.Events.MediaChanged -= new EventHandler<MediaPlayerMediaChanged>(Events_MediaChanged);
                m_player.Events.PlayerPositionChanged -= new EventHandler<MediaPlayerPositionChanged>(Events_PlayerPositionChanged);
            }
        }

        /// <summary>
        /// Add\remove media events
        /// </summary>
        /// <returns></returns>
        private void RegisterMediaEvents(bool on)
        {
            if (on)
            {
                //m_media.Events.DurationChanged += new EventHandler<MediaDurationChange>(Events_DurationChanged);
                //m_media.Events.ParsedChanged += new EventHandler<MediaParseChange>(Events_ParsedChanged);
                m_media.Events.StateChanged += new EventHandler<MediaStateChange>(Events_StateChanged);
            }
            else
            {
                //m_media.Events.DurationChanged -= new EventHandler<MediaDurationChange>(Events_DurationChanged);
                //m_media.Events.ParsedChanged -= new EventHandler<MediaParseChange>(Events_ParsedChanged);
                m_media.Events.StateChanged -= new EventHandler<MediaStateChange>(Events_StateChanged);
            }
        }

        private void Events_StateChanged(object sender, MediaStateChange e)
        {
            switch (e.NewState)
            {
                case MediaState.Opening:
                    info.cam.data.IsOpening = true;
                    break;
                case MediaState.Buffering:
                    info.cam.data.IsBuffering = true;
                    break;
                case MediaState.Playing:
                    info.cam.data.IsPlaying = true;
                    break;
                case MediaState.Paused:
                    info.cam.data.IsPaused = true;
                    break;
                case MediaState.Stopped:
                    if (!info.cam.data.IsStopped)
                    {
                        SetBtnsVisibilityOnPlay(false);
                    }
                    info.cam.data.IsStopped = true;
                    break;
                case MediaState.Ended:
                    info.cam.data.IsEnded = true;

                    UISync.Execute(() => TextUpdate(form.lblVlcNotify,
                        " Vlc stopped ... ", false, false, false));

                    UISync.Execute(() => VlcReinit());

                    break;
                case MediaState.Error:
                    info.cam.data.IsError = true;

                    UISync.Execute(() => VlcReinit());

                    break;
                default:
                    break;
            }

            if (m_player != null)
                SessionInfo.playing = m_player.IsPlaying;
        }



        void Events_MediaChanged(object sender, MediaPlayerMediaChanged e)
        {
            info.cam.data.MediaChanged = true;
        }

        private void Data_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Log(e.PropertyName);
        }





        internal void Log(string s)
        {
            if (_logTimeLast == DateTime.MinValue)//connection start
            {
                _logTimeLast = DateTime.Now;

                UISync.Execute(() =>
                TextUpdate(form.txtDev,
                     Environment.NewLine +
                     string.Format("{0:00}:{1:00}:{2:00}.{3:000}          ---    Conexiune pornita   ---",
                    _logTimeLast.Hour, _logTimeLast.Minute, _logTimeLast.Second, _logTimeLast.Millisecond)
                    , true, true, false));
            }

            _logTimeNow = DateTime.Now;
            UISync.Execute(() =>
            TextUpdate(form.txtDev,
                string.Format("{0:00}:{1:00}:{2:00}.{3:000} {4} a inceput in {5} ms {6}",
                    _logTimeLast.Hour, _logTimeLast.Minute, _logTimeLast.Second, _logTimeLast.Millisecond, s,
                    ((int)_logTimeNow.Subtract(_logTimeLast).TotalMilliseconds).ToString(), Environment.NewLine)
                    , true, false, true));

        }

        private void TextUpdate(Control ctrl, string s, bool add, bool logAppend, bool updateDateLog)
        {
            if (add)
            {
                if (logAppend)
                {
                    string ipTxt = "", sidTxt = "";
                    if (form.comboAddress.Text.Length > 3)
                    {
                        int ips = form.comboAddress.Text.IndexOf('/', 6), ipf = form.comboAddress.Text.IndexOf('/', 7);
                        ipTxt = form.comboAddress.Text.Substring(ips + 1, ipf - ips - 1) + sidTxt;
                        sidTxt = form.comboAddress.Text.Substring(ipf + 1, form.comboAddress.Text.Length - ipf - 1) + sidTxt;

                        ipTxt = "              IP: " + ipTxt + Environment.NewLine;
                        sidTxt = "                       " + sidTxt;
                    }

                    s = s + Environment.NewLine + sidTxt + ipTxt;
                }

                if (ctrl is TextBoxBase) (ctrl as TextBoxBase).AppendText(s);
                else
                    ctrl.Text += s;
            }
            else
                ctrl.Text = s;

            if (updateDateLog) _logTimeLast = _logTimeNow;

            //DateTime dt = DateTime.Now;
            //textLog.AppendText(string.Format("{0:00}:{1:00}:{2:00}.{3:000} ",
            //dt.Hour, dt.Minute, dt.Second, dt.Millisecond) + sir + Environment.NewLine);
        }


    }
}
