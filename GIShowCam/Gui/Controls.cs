using GIShowCam.Info;
using GIShowCam.Utils;
using System;

namespace GIShowCam.Gui
{
    internal partial class GuiBase
    {
        private bool _btnsShowOnPlay;
        private int _lblEventsShowCount = 64;
        internal void InitGuiControls()
        {


            foreach (var dev in _info.GetDeviceList()) _form.comboAddress.Items.Add(dev);


            _form.comboAddress.SelectedIndex = _info.DevId;

        }

        internal void AddFormEvents()
        {
            _form.btnDevConnect.Click += BtnDevConnect_Click;
            _form.btnPlay.Click += BtnPlay_Click;

            _form.chkFullVid.CheckedChanged += ChkFullVideo_CheckedChanged;

            //TextBox changed events:
            _form.comboAddress.TextChanged += TxtDevAddress_TextChanged;
            _form.txtDevUser.TextChanged += TxtDevUser_TextChanged;
            _form.txtDevPass.TextChanged += TxtDevPass_TextChanged;

            _form.comboAddress.SelectionChangeCommitted += ComboAddress_SelectionChangeCommitted;

            _form.btnRatio.Text = _info.Cam.Data.ViewSettings.AspectRatioMode.ToString();
            _form.btnRatio.Click += BtnRatio_Click;
        }

        private void BtnRatio_Click(object sender, EventArgs e)
        {
            ToggleAspectRatio();
        }

        private void ToggleAspectRatio()
        {
            if (_mPlayer != null)
            {
                ViewSettings setari = _info.Cam.Data.ViewSettings;

                bool aspectDefault = _mPlayer.AspectRatio == setari.AspectRatioDefault;

                _mPlayer.AspectRatio = (aspectDefault) ?           // AspectRatio e Default
                    setari.AspectRatioMode :                       // Mode 2
                    setari.AspectRatioDefault;                     // Default

                //  Notificari optionale
                _form.btnRatio.Text = (aspectDefault) ? setari.AspectRatioDefault.ToString() : setari.AspectRatioMode.ToString();

                _lblEventsShowCount = 10;
                _form.lblEvent.Text = @"Event: aspect ratio change from " + ((aspectDefault) ?
                    (VlcUtils.AspectRatioToString(setari.AspectRatioDefault) + " to " +
                    VlcUtils.AspectRatioToString(setari.AspectRatioMode)) :
                    (VlcUtils.AspectRatioToString(setari.AspectRatioMode) + " to " +
                    VlcUtils.AspectRatioToString(setari.AspectRatioDefault)));
            }
            else
            {
                _form.lblEvent.Text = @"No video, cannot change aspect ratio";
            }
        }

        private static void ChkFullVideo_CheckedChanged(object sender, EventArgs e)
        {
            /*
            SessionInfo.fullVideo = ((CheckBox)sender).Checked;
            if (vlc != null)
                if (SessionInfo.fullVideo)
                {
                    SessionInfo.log = false;
                    VideoInit(true, true, false);
                    vlc.Play();
                }
                else
                {
                    SessionInfo.log = true;
                    VideoInit(false, true, false);
                    vlc.Play();
                }*/
        }

        /*
        void VlcControl_EndReached(VlcControl sender, VlcEventArgs<EventArgs> e)
        {
            if (vlc != null && vlc.GetCurrentMedia() != null)
            {
                //System.Threading.Thread.Sleep(20);
                BtnDevConnect_Click(null, null);
            }
        }*/
        /*
        if (vlc.State == Vlc.DotNet.Core.Interops.Signatures.LibVlc.Media.States.Ended)
        {
            var subItems = vlc.Medias;
            if (subItems.Count > 0)
            {
                vlc.Play(subItems[0]);
            }
        }*/



        private void BtnPlay_Click(object sender, EventArgs e)
        {
            _form.lblEvent.Text = null;

            if (_mPlayer != null && _mPlayer.IsPlaying)
            {
                _form.btnPlay.Text = @"Play";
                TextUpdate(_form.lblVlcNotify, " pauza de ... ", false, false, false);
                //m_player.Stop();
                ToggleRunningMedia(false);
            }
            else
            {
                _form.btnPlay.Text = @"Stop";
                //m_player.Play();
                ToggleRunningMedia(true);
            }
            SetBtnsVisibilityOnPlay(_mPlayer?.IsPlaying ?? false);
        }

        private void SetBtnsVisibilityOnPlay(bool on)
        {

            if (_btnsShowOnPlay != on)
            {
                if (on || (!_info.Cam.Data.IsPlaying))
                    _form.btnPlay.Enabled = on;
                _form.btnSnapshot.Enabled = on;
                _form.btnRecord.Enabled = on;
            }

            _btnsShowOnPlay = on;
        }

        #region Detalii pt connection textboxes

        private void TxtDevPass_TextChanged(object sender, EventArgs e)
        {
            _info.Password = _form.txtDevPass.Text;
        }

        private void TxtDevUser_TextChanged(object sender, EventArgs e)
        {
            _info.User = _form.txtDevUser.Text;
        }

        private void TxtDevAddress_TextChanged(object sender, EventArgs e)
        {
            _info.Host = _form.comboAddress.Text;
        }

        internal void DeviceTextBoxesUpdate(bool updateCamInfo)
        {
            if (updateCamInfo) _info.NewCameraInfo();

            _form.txtDevUser.Text = _info.User;
            _form.txtDevPass.Text = _info.Password;
            _form.comboAddress.Text = _info.Host;
        }

        #endregion Detalii pt connection textboxes

    }
}
