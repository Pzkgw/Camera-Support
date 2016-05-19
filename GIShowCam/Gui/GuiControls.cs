using Declarations;
using GIShowCam.Info;
using System;
using System.Windows.Forms;

namespace GIShowCam.Gui
{
    internal partial class GuiBase
    {
        private bool btnsShowOnPlay;
        private int lblEventsShowCount = 64;
        internal void InitGuiControls()
        {


            foreach (string dev in info.GetDeviceList()) form.comboAddress.Items.Add(dev);


            form.comboAddress.SelectedIndex = info.devID;

        }

        internal void AddFormEvents()
        {
            form.btnDevConnect.Click += BtnDevConnect_Click;
            form.btnPlay.Click += BtnPlay_Click;


            form.chkPlayLoop.CheckedChanged += ChkLoop_CheckedChanged;
            form.chkFullVid.CheckedChanged += ChkFullVideo_CheckedChanged;

            //TextBox changed events:
            form.comboAddress.TextChanged += TxtDevAddress_TextChanged;
            form.txtDevUser.TextChanged += TxtDevUser_TextChanged;
            form.txtDevPass.TextChanged += TxtDevPass_TextChanged;

            form.comboAddress.SelectionChangeCommitted += ComboAddress_SelectionChangeCommitted;

            form.btnRatio.Text = info.cam.data.viewSettings.aspectRatioMode.ToString();
            form.btnRatio.Click += BtnRatio_Click;
        }

        private void BtnRatio_Click(object sender, EventArgs e)
        {
            ViewSettings setari = info.cam.data.viewSettings;

            bool aspectDefault = m_player.AspectRatio == setari.aspectRatioDefault;

            m_player.AspectRatio = (aspectDefault) ?           // AspectRatio e Default
                setari.aspectRatioMode :                       // Mode 2
                setari.aspectRatioDefault;                     // Default

            //  Notificari optionale
            form.btnRatio.Text = (aspectDefault) ? setari.aspectRatioDefault.ToString() : setari.aspectRatioMode.ToString();

            lblEventsShowCount = 16;
            form.lblEvent.Text = "Event: aspect ratio change from " + ((aspectDefault) ?
                (setari.aspectRatioDefault.ToString() + " to " + setari.aspectRatioMode.ToString()) :
                (setari.aspectRatioMode.ToString() + " to " + setari.aspectRatioDefault.ToString()));
        }

        private void ChkFullVideo_CheckedChanged(object sender, EventArgs e)
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

        private void ChkLoop_CheckedChanged(object sender, EventArgs e)
        {
            /*
            info.videoLoop = ((CheckBox)sender).Checked;
            if (vlc != null)
                if (info.videoLoop)
                {
                    vlc.Pause();
                    vlc.Play();
                }
                else
                {
                    vlc.Pause();
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

            if (m_player.IsPlaying)
            {
                form.btnPlay.Text = "Play";
                TextUpdate(form.lblVlcNotify, " pauza de ... ", false, false, false);
                m_player.Stop();
            }
            else
            {
                form.btnPlay.Text = "Stop";
                m_player.Play();
            }

            SetBtnsVisibilityOnPlay(m_player.IsPlaying);

            /*
            bool playing = false;
            if (sender != null && vlc != null)
            {
                playing = vlc.State == Vlc.DotNet.Core.Interops.Signatures.MediaStates.Playing;
                if (playing)
                {                    
                    vlc.Stop(false);
                }
                else
                {
                    vlc.Play();
                }
                SetBtnsVisibilityOnPlay(!playing);
            }   */
        }

        #region Detalii pt connection textboxes

        private void TxtDevPass_TextChanged(object sender, EventArgs e)
        {
            info.password = form.txtDevPass.Text;
        }

        private void TxtDevUser_TextChanged(object sender, EventArgs e)
        {
            info.user = form.txtDevUser.Text;
        }

        private void TxtDevAddress_TextChanged(object sender, EventArgs e)
        {
            info.host = form.comboAddress.Text;
        }

        #endregion Detalii pt connection textboxes

    }
}
