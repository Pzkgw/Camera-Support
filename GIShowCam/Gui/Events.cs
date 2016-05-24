using Declarations;
using Declarations.Events;
using GIShowCam.Info;
using GIShowCam.Utils;
using System;
using System.Runtime.InteropServices;
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
        private void RegisterPlayerEvents(bool on)
        {
            if (on)
            {
                _mPlayer.Events.MediaChanged += Events_MediaChanged;
                _mPlayer.Events.PlayerPositionChanged += Events_PlayerPositionChanged;
                _mPlayer.Events.PlayerSnapshotTaken += Events_PlayerSnapshotTaken;
            }
            else
            {
                _mPlayer.Events.MediaChanged -= Events_MediaChanged;
                _mPlayer.Events.PlayerPositionChanged -= Events_PlayerPositionChanged;
                _mPlayer.Events.PlayerSnapshotTaken -= Events_PlayerSnapshotTaken;
            }
        }

        private void Events_PlayerSnapshotTaken(object sender, MediaPlayerSnapshotTaken e)
        {
            UiSync.Execute(() => LogEvent(@"Snapshot salvat in " + SessionInfo.SnapshotDir + e.FileName));
        }

        private void LogEvent(string s)
        {
            _form.lblEvent.Text = s;
            _lblEventsShowCount = 8;
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
                _mMedia.Events.StateChanged += Events_StateChanged;
            }
            else
            {
                //m_media.Events.DurationChanged -= new EventHandler<MediaDurationChange>(Events_DurationChanged);
                //m_media.Events.ParsedChanged -= new EventHandler<MediaParseChange>(Events_ParsedChanged);
                _mMedia.Events.StateChanged -= Events_StateChanged;
            }
        }

        private void Events_StateChanged(object sender, MediaStateChange e)
        {
            switch (e.NewState)
            {
                case MediaState.Opening:
                    _info.Cam.Data.IsOpening = true;
                    break;
                case MediaState.Buffering:
                    _info.Cam.Data.IsBuffering = true;
                    break;
                case MediaState.Playing:
                    _info.Cam.Data.IsPlaying = true;
                    break;
                case MediaState.Paused:
                    _info.Cam.Data.IsPaused = true;
                    break;
                case MediaState.Stopped:
                    if (!_info.Cam.Data.IsStopped)
                    {
                        UiSync.Execute(() => SetBtnsVisibilityOnPlay(false));
                    }
                    _info.Cam.Data.IsStopped = true;
                    break;
                case MediaState.Ended:
                    UiSync.Execute(() => StartVlcReinit(true));
                    break;
                case MediaState.Error:
                    UiSync.Execute(() => StartVlcReinit(false));
                    break;
                case MediaState.NothingSpecial:
                    break;
            }

            if (_mPlayer != null)
                SessionInfo.Playing = _mPlayer.IsPlaying;
        }

        private void Events_MediaChanged(object sender, MediaPlayerMediaChanged e)
        {
            _info.Cam.Data.MediaChanged = true;
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

                UiSync.Execute(() =>
                TextUpdate(_form.txtDev,
                     Environment.NewLine +
                     $"{_logTimeLast.Hour:00}:{_logTimeLast.Minute:00}:{_logTimeLast.Second:00}.{_logTimeLast.Millisecond:000}          ---    Conexiune pornita   ---"
                    , true, true, false));
            }

            _logTimeNow = DateTime.Now;
            UiSync.Execute(() =>
            TextUpdate(_form.txtDev,
                $"{_logTimeLast.Hour:00}:{_logTimeLast.Minute:00}:{_logTimeLast.Second:00}.{_logTimeLast.Millisecond:000} {s} a inceput in {((int)_logTimeNow.Subtract(_logTimeLast).TotalMilliseconds).ToString()} ms {Environment.NewLine}"
                , true, false, true));

        }

        private void TextUpdate(Control ctrl, string s, bool add, bool logAppend, bool updateDateLog)
        {
            if (add)
            {
                if (logAppend)
                {
                    string ipTxt = "", sidTxt = "";
                    if (_form.comboAddress.Text.Length > 3)
                    {
                        int ips = _form.comboAddress.Text.IndexOf('/', 6), ipf = _form.comboAddress.Text.IndexOf('/', 7);
                        ipTxt = _form.comboAddress.Text.Substring(ips + 1, ipf - ips - 1) + sidTxt;
                        sidTxt = _form.comboAddress.Text.Substring(ipf + 1, _form.comboAddress.Text.Length - ipf - 1) + sidTxt;

                        ipTxt = "              IP: " + ipTxt + Environment.NewLine;
                        sidTxt = "                       " + sidTxt;
                    }

                    s = s + Environment.NewLine + sidTxt + ipTxt;
                }

                var @base = ctrl as TextBoxBase;
                if (@base != null) @base.AppendText(s);
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
