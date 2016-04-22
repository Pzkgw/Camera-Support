using GIShowCam.Info;
using System;
using System.Windows.Forms;
using Vlc.DotNet.Core;
using Vlc.DotNet.Core.Medias;
using Vlc.DotNet.Forms;

namespace GIShowCam.Gui
{
    class GuiControls : GuiBase
    {
        Label lblVlcNotifications;

        TextBox txtDevAddress, txtDevUser, txtDevPass;

        bool playIsOn, recordIsOn;

        public GuiControls(GuiBase mainB, Button btnDevConnect,
            TextBox txtDevAddress, TextBox txtDevUser, TextBox txtDevPass, 
            Button btnPlay, Button btnSnapshot, Button btnRecord, Label lblVlcNotify) : base(mainB)
        {

            lblVlcNotifications = lblVlcNotify;

            txtDevAddress.Text = SessionInfo.host;
            txtDevUser.Text = SessionInfo.user;
            txtDevPass.Text = SessionInfo.pass;

            this.txtDevAddress = txtDevAddress;
            this.txtDevUser = txtDevUser;
            this.txtDevPass = txtDevPass;


            vlc.Playing += Vlc_Playing;            
            vlc.EndReached += vlcControl_EndReached;
            vlc.PositionChanged += VlcControlOnPositionChanged;

            BtnPlay_Click(btnPlay, null);
            btnPlay.Click += BtnPlay_Click;

            BtnDevConnect_Click(btnDevConnect, null);
            btnDevConnect.Click += BtnDevConnect_Click;


            AddDevConnectTextEvents();

            btnSnapshot.Click += BtnSnapshot_Click;
            btnRecord.Click += BtnRecord_Click;
        }

        private void BtnRecord_Click(object sender, EventArgs e)
        {
            if (recordIsOn)
            {

                recordIsOn = false;
            }
            else
            {

                recordIsOn = true;
            }
        }

        private void BtnSnapshot_Click(object sender, EventArgs e)
        {
            //vlc.Media.
        }

        private void BtnDevConnect_Click(object sender, EventArgs e)
        {
            if (vlc.IsPlaying) vlc.Stop();
            VideoPlay();
        }


        private void Media_StateChanged(MediaBase sender, VlcEventArgs<Vlc.DotNet.Core.Interops.Signatures.LibVlc.Media.States> e)
        {
            //form.ControlTextUpdate(lblVlcNotifications, "State: " + e.Data.ToString());
        }

        private void Vlc_Playing(VlcControl sender, VlcEventArgs<EventArgs> e)
        {
            if (!playIsOn && vlc.IsPlaying) playIsOn = true;
        }


        void vlcControl_EndReached(VlcControl sender, VlcEventArgs<EventArgs> e)
        {
            vlc.Pause();
            //listBoxPeUndeva.SelectedIndex += 1;
        }

        /// <summary>
        /// Event handler for "VlcControl.PositionChanged" event. 
        /// Updates the label containing the playback position. 
        /// </summary>
        /// <param name="sender">Event sending. </param>
        /// <param name="e">Event arguments, containing the current position. </param>
        private void VlcControlOnPositionChanged(VlcControl sender, VlcEventArgs<float> e)
        {
            //form.ControlTextUpdate(labelPlaybackPosition, "Pozitie(doar pentru video local) : " + (e.Data * 100).ToString("000") + " %");
            form.ControlTextUpdate(lblVlcNotifications, "FPS: " + vlc.FPS);
        }

        #region Additional Controls



        private void BtnPlay_Click(object sender, EventArgs e)
        {
            if (playIsOn)
            {
                if (vlc.IsPlaying) vlc.Pause();
                playIsOn = false;
            }
            else
            {
                if (!vlc.IsPlaying) vlc.Play();
                playIsOn = true;
            }

            ((Button)sender).Text = playIsOn ? "Pause" : "Play";
            ((Button)sender).Update();
        }


        #endregion Additional Controls






        private void AddDevConnectTextEvents()
        {
            txtDevAddress.TextChanged += TxtDevAddress_TextChanged;
            txtDevUser.TextChanged += TxtDevUser_TextChanged;
            txtDevPass.TextChanged += TxtDevPass_TextChanged;
        }

        private void TxtDevPass_TextChanged(object sender, EventArgs e)
        {
            SessionInfo.pass = txtDevPass.Text;
        }

        private void TxtDevUser_TextChanged(object sender, EventArgs e)
        {
            SessionInfo.user = txtDevUser.Text;
        }

        private void TxtDevAddress_TextChanged(object sender, EventArgs e)
        {
            SessionInfo.host = txtDevAddress.Text;
        }


    }
}
