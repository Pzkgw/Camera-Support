using GIShowCam.Info;
using System;
using System.Windows.Forms;
using Vlc.DotNet.Core;

namespace GIShowCam.Gui
{
    internal partial class GuiBase
    {
        Label lblVlcNotifications;

        ComboBox comboAddress;
        TextBox txtDevUser, txtDevPass;

        Button btnPlay;

        internal void InitGuiControls(GuiBase mainB, Button btnDevConnect,
            ComboBox comboTxtAddress, TextBox txtDevUser, TextBox txtDevPass,
            TextBox textBoxWidthF, TextBox textBoxHeightF,
            Button btnPlay, CheckBox chkLoop, CheckBox chkFullVideo, Label lblVlcNotify)
        {

            this.lblVlcNotifications = lblVlcNotify;
            this.btnPlay = btnPlay;
            this.comboAddress = comboTxtAddress;
            this.txtDevUser = txtDevUser;
            this.txtDevPass = txtDevPass;

            FillDeviceInfo();

            //vlc.EndReached += VlcControl_EndReached;
            //vlc.PositionChanged += VlcControlOnPositionChanged;


            btnDevConnect.Click += BtnDevConnect_Click;
            btnPlay.Click += BtnPlay_Click;


            chkLoop.CheckedChanged += ChkLoop_CheckedChanged;
            chkFullVideo.CheckedChanged += ChkFullVideo_CheckedChanged;

            //TextBox changed events:
            comboAddress.TextChanged += TxtDevAddress_TextChanged;
            txtDevUser.TextChanged += TxtDevUser_TextChanged;
            txtDevPass.TextChanged += TxtDevPass_TextChanged;

            ComboAddress_SelectionChangeCommitted(null, null);
        }

        private void ChkFullVideo_CheckedChanged(object sender, EventArgs e)
        {
            SessionInfo.fullVideo = ((CheckBox)sender).Checked;
            if (vlc != null)
                if (SessionInfo.fullVideo)
                {
                    form.panelVlc.Click -= PanelVlc_Click;
                    SessionInfo.log = false;
                    vlc.Pause();
                    FullVideo(true, false);
                    //if (info.videoLoop) vlc.Play(); else vlc.NextFrame();
                    vlc.Play();
                }
                else
                {
                    SessionInfo.log = true;
                    vlc.Pause();
                    FullVideo(false, false);
                    vlc.Play();
                }
        }

        private void ChkLoop_CheckedChanged(object sender, EventArgs e)
        {
            info.videoLoop = ((CheckBox)sender).Checked;
            if (vlc != null)
                if (info.videoLoop)
                {
                    form.panelVlc.Click -= PanelVlc_Click;
                    vlc.Pause();
                    vlc.Play();
                }
                else
                {
                    vlc.Pause();
                    form.panelVlc.Click += PanelVlc_Click;
                }
        }

        private void PanelVlc_Click(object sender, EventArgs e)
        {
            //vlc.NextFrame();
        }

        private void FillDeviceInfo()
        {
            foreach (string dev in info.GetDeviceList())
                comboAddress.Items.Add(dev);
            comboAddress.SelectedIndex = info.devID;
            comboAddress.SelectionChangeCommitted += ComboAddress_SelectionChangeCommitted;
        }

        private void ComboAddress_SelectionChangeCommitted(object sender, EventArgs e)
        {
            info.Select(comboAddress.SelectedIndex);
            info.cam.data.PropertyChanged += Data_PropertyChanged;
            txtDevUser.Text = info.user;
            txtDevPass.Text = info.password;
            comboAddress.Text = info.host;

            BtnDevConnect_Click(null, null);
        }

        private void Data_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            form.Log(e.PropertyName);
        }

        private void BtnDevConnect_Click(object sender, EventArgs e)
        {
            VideoPlayInit();
            if (vlc != null && vlc.GetCurrentMedia() != null)
            {
                info.cam.data.IsStarted = true;
                //foreach(EventHandler evh in vlc.Media.StateChanged)
                //vlc.Media.StateChanged -= Media_StateChanged;
                vlc.GetCurrentMedia().StateChanged += GuiBase_StateChanged;
                vlc.EncounteredError += Vlc_EncounteredError;
                //VlcContext.
                vlc.Play();
            }
            else
            {
                MessageBox.Show("Eroare la conexiune");
            }
        }



        private void Vlc_EncounteredError(object sender, VlcMediaPlayerEncounteredErrorEventArgs e)
        {
            MessageBox.Show(e.ToString());
        }

        private void GuiBase_StateChanged(object sender, VlcMediaStateChangedEventArgs e)
        {
            /*
            if (vlc.State == Vlc.DotNet.Core.Interops.Signatures.MediaStates.NothingSpecial)
                form.Log("Connection start"); //connection start
            else
                form.Log("Connection state: " + vlc.State);*/

            switch (vlc.State)
            {
                case Vlc.DotNet.Core.Interops.Signatures.MediaStates.Opening:
                    info.cam.data.IsOpening = true;
                    break;
                case Vlc.DotNet.Core.Interops.Signatures.MediaStates.Buffering:
                    //info.cam.data.IsBuffering = true;
                    break;
                case Vlc.DotNet.Core.Interops.Signatures.MediaStates.Playing:
                    info.cam.data.IsPlaying = true;
                    break;
                case Vlc.DotNet.Core.Interops.Signatures.MediaStates.Paused:
                    info.cam.data.IsPaused = true;
                    break;
                case Vlc.DotNet.Core.Interops.Signatures.MediaStates.Stopped:
                    info.cam.data.IsStopped = true;
                    break;
                case Vlc.DotNet.Core.Interops.Signatures.MediaStates.Ended:
                    info.cam.data.IsEnded = true;
                    break;
                case Vlc.DotNet.Core.Interops.Signatures.MediaStates.Error:
                    info.cam.data.IsError = true;
                    break;
                default:
                    break;
            }


            if (vlc.State == Vlc.DotNet.Core.Interops.Signatures.MediaStates.Playing) //play vlc start
            {
                form.ControlShow(btnPlay, true);
                form.ControlShow(form.btnSnapshot, true);
                form.ControlShow(form.btnRecord, true);
                BtnPlay_Click(null, null);
            }
            else
            {
                form.ControlShow(form.btnSnapshot, false);
                form.ControlShow(form.btnRecord, false);
                //BtnPlay_Click(null, null);                
            }
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

        /*
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

                    if (vlc != null && vlc.GetCurrentMedia() != null)
                        form.ControlTextUpdate(lblVlcNotifications,
                            "DecodedVideo: " + vlc.GetCurrentMedia().Statistics.DecodedVideo +
                            "  InputBitrate: " + vlc.GetCurrentMedia().Statistics.InputBitrate +
                            "  DemuxBitrate: " + vlc.GetCurrentMedia().Statistics.DemuxBitrate +
                            "  DisplayedPictures: " + vlc.GetCurrentMedia().Statistics.DisplayedPictures +
                            "  LostPictures: " + vlc.GetCurrentMedia().Statistics.LostPictures);
                }
                */
        #region Additional Controls



        private void BtnPlay_Click(object sender, EventArgs e)
        {
            bool playing = false;
            if (sender != null && vlc != null)
            {
                playing = vlc.State == Vlc.DotNet.Core.Interops.Signatures.MediaStates.Playing;
                if (playing)
                {
                    if (vlc.IsPlaying) vlc.Stop();
                }
                else
                {
                    if (!vlc.IsPlaying) vlc.Play();
                }
            }

            form.ControlTextUpdate(btnPlay, playing ? "Stop" : "Play");
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
