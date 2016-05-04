using GIShowCam.Info;
using System;
using System.Windows.Forms;

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

        #region Additional Controls



        private void BtnPlay_Click(object sender, EventArgs e)
        {
            bool playing = false;
            if (sender != null && vlc != null)
            {
                playing = vlc.State == Vlc.DotNet.Core.Interops.Signatures.MediaStates.Playing;
                if (playing)
                {
                    vlc.Stop();
                }
                else
                {
                    info.cam.data.Start();
                    vlc.Play();
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
