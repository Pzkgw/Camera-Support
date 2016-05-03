using GIShowCam.Info;
using System;
using System.Windows.Forms;
using Vlc.DotNet.Core;

namespace GIShowCam.Gui
{
    internal partial class GuiBase
    {
        internal void InitGuiControls()
        {

            foreach (string dev in info.GetDeviceList())
                form.comboAddress.Items.Add(dev);
            form.comboAddress.SelectedIndex = info.devID;
            form.comboAddress.SelectionChangeCommitted += ComboAddress_SelectionChangeCommitted;

            //vlc.EndReached += VlcControl_EndReached;
            //vlc.PositionChanged += VlcControlOnPositionChanged;


            form.btnDevConnect.Click += BtnDevConnect_Click;
            form.btnPlay.Click += BtnPlay_Click;


            form.chkPlayLoop.CheckedChanged += ChkLoop_CheckedChanged;
            form.chkFullVid.CheckedChanged += ChkFullVideo_CheckedChanged;

            //TextBox changed events:
            form.comboAddress.TextChanged += TxtDevAddress_TextChanged;
            form.txtDevUser.TextChanged += TxtDevUser_TextChanged;
            form.txtDevPass.TextChanged += TxtDevPass_TextChanged;

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
                    VideoInit(true, false);
                    //if (info.videoLoop) vlc.Play(); else vlc.NextFrame();
                    vlc.Play();
                }
                else
                {
                    SessionInfo.log = true;
                    vlc.Pause();
                    VideoInit(false, false);
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


        private void Data_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            form.Log(e.PropertyName);
            form.ControlTextUpdate(form.btnPlay, (vlc != null && vlc.IsPlaying) ? "Stop" : "Play");
        }


        private void Vlc_EncounteredError(object sender, VlcMediaPlayerEncounteredErrorEventArgs e)
        {
            MessageBox.Show(e.ToString());
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
        }

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


        #endregion Additional Controls

    }
}
