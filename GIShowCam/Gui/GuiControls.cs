﻿using GIShowCam.Info;
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

        ComboBox comboAddress;
        TextBox txtDevUser, txtDevPass;

        Button btnPlay;

        bool playIsOn;

        public GuiControls(GuiBase mainB, Button btnDevConnect,
            ComboBox comboTxtAddress, TextBox txtDevUser, TextBox txtDevPass, 
            TextBox textBoxWidthF, TextBox textBoxHeightF,
            Button btnPlay, Label lblVlcNotify) : base(mainB)
        {

            
            txtDevUser.Text = info.user;
            txtDevPass.Text = info.password;
            comboTxtAddress.Text = info.host;

            this.lblVlcNotifications = lblVlcNotify;
            this.btnPlay = btnPlay;
            this.comboAddress = comboTxtAddress;
            this.txtDevUser = txtDevUser;
            this.txtDevPass = txtDevPass;

            vlc.Playing += Vlc_Playing;            
            vlc.EndReached += vlcControl_EndReached;
            vlc.PositionChanged += VlcControlOnPositionChanged;

            BtnDevConnect_Click(btnDevConnect, null);            

            btnDevConnect.Click += BtnDevConnect_Click;
            btnPlay.Click += BtnPlay_Click;

            FillDeviceInfo();

            //TextBox changed events:
            comboAddress.TextChanged += TxtDevAddress_TextChanged;
            txtDevUser.TextChanged += TxtDevUser_TextChanged;
            txtDevPass.TextChanged += TxtDevPass_TextChanged;

            textBoxWidthF.TextChanged += TextBoxWidthF_TextChanged;
            textBoxHeightF.TextChanged += textBoxHeightF_TextChanged;
        }

        private void FillDeviceInfo()
        {
            foreach (string dev in info.GetDeviceList())
                comboAddress.Items.Add(dev);
            comboAddress.SelectedIndex = 0;
            comboAddress.SelectionChangeCommitted += ComboAddress_SelectionChangeCommitted;
        }

        private void ComboAddress_SelectionChangeCommitted(object sender, EventArgs e)
        {
            info.Select(comboAddress.SelectedIndex); 
            txtDevUser.Text = info.user;
            txtDevPass.Text = info.password;
            comboAddress.Text = info.host;

            BtnDevConnect_Click(null, null);
        }

        private void TextBoxWidthF_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBoxHeightF_TextChanged(object sender, EventArgs e)
        {
            
        }


        



        private void BtnDevConnect_Click(object sender, EventArgs e)
        {
            VideoPlayInit();
            if (vlc != null && vlc.Media != null)
            {
                vlc.Media.StateChanged += Media_StateChanged;
                //vlc.NextFrame();
                vlc.Play();
            }
        }

        private void Media_StateChanged(MediaBase sender, VlcEventArgs<Vlc.DotNet.Core.Interops.Signatures.LibVlc.Media.States> e)
        {
            //form.ControlTextUpdate(lblVlcNotifications, "State: " + e.Data.ToString());
            if (e.Data == Vlc.DotNet.Core.Interops.Signatures.LibVlc.Media.States.NothingSpecial)
                form.Log("Connection start"); //connection start
            else
                form.Log("Connection state: " + e.Data.ToString());
            //form.ControlTextUpdate(lblVlcNotifications, e.Data.ToString());

            if (e.Data == Vlc.DotNet.Core.Interops.Signatures.LibVlc.Media.States.Playing) //play vlc start
            {
                playIsOn = true;
                form.ControlShow(btnPlay, true);
                form.ControlShow(form.btnSnapshot, true);
                form.ControlShow(form.btnRecord, true);
                BtnPlay_Click(null, null);                
            }
            else
            {
                playIsOn = false;
                form.ControlShow(form.btnSnapshot, false);
                form.ControlShow(form.btnRecord, false);
                BtnPlay_Click(null, null);                
            }
        }

        private void Vlc_Playing(VlcControl sender, VlcEventArgs<EventArgs> e)
        {
            //form.Log("Vlc play event: " + e.Data.ToString());
        }


        void vlcControl_EndReached(VlcControl sender, VlcEventArgs<EventArgs> e)
        {
            if(vlc != null && vlc.Media != null)
            {
                BtnDevConnect_Click(null, null);
            }
            
            /*
            if (vlc.State == Vlc.DotNet.Core.Interops.Signatures.LibVlc.Media.States.Ended)
            {
                var subItems = vlc.Medias;
                if (subItems.Count > 0)
                {
                    vlc.Play(subItems[0]);
                }
            }*/
        }

        /// <summary>
        /// Event handler for "VlcControl.PositionChanged" event. 
        /// Updates the label containing the playback position. 
        /// </summary>
        /// <param name="sender">Event sending. </param>
        /// <param name="e">Event arguments, containing the current position. </param>
        private void VlcControlOnPositionChanged(VlcControl sender, VlcEventArgs<float> e)
        {
            //form.ControlTextUpdate(lblVlcNotifications, "Pozitie(doar pentru video local) : " + (e.Data * 100).ToString("000") + " %");
            //form.ControlTextUpdate(lblVlcNotifications, "FPS: " + vlc.FPS);

            if (vlc != null && vlc.Media != null)
                form.ControlTextUpdate(lblVlcNotifications,
                    "DecodedVideo: " + vlc.Media.Statistics.DecodedVideo +
                    "  InputBitrate: " + vlc.Media.Statistics.InputBitrate +
                    "  DemuxBitrate: " + vlc.Media.Statistics.DemuxBitrate +
                    "  DisplayedPictures: " + vlc.Media.Statistics.DisplayedPictures +
                    "  LostPictures: " + vlc.Media.Statistics.LostPictures);
        }

        #region Additional Controls



        private void BtnPlay_Click(object sender, EventArgs e)
        {
            if (sender != null)
                if (playIsOn)
                {
                    if (vlc.IsPlaying) vlc.Stop();
                }
                else
                {
                    if (!vlc.IsPlaying) vlc.Play();
                }

            form.ControlTextUpdate(btnPlay, playIsOn ? "Stop" : "Play");
        }


        #endregion Additional Controls


        private void TxtDevPass_TextChanged(object sender, EventArgs e)
        {
            info.password = txtDevPass.Text;
        }

        private void TxtDevUser_TextChanged(object sender, EventArgs e)
        {
            info.user = txtDevUser.Text;
        }

        private void TxtDevAddress_TextChanged(object sender, EventArgs e)
        {
            info.host = comboAddress.Text;
        }


    }
}
