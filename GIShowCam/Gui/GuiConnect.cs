
using System;
using System.Windows.Forms;
using Vlc.DotNet.Core;

namespace GIShowCam.Gui
{
    internal partial class GuiBase
    {

        private void ComboAddress_SelectionChangeCommitted(object sender, EventArgs e)
        {
            info.Select(form.comboAddress.SelectedIndex);
            info.cam.data.PropertyChanged += Data_PropertyChanged;
            form.txtDevUser.Text = info.user;
            form.txtDevPass.Text = info.password;
            form.comboAddress.Text = info.host;

            BtnDevConnect_Click(null, null);
        }

        private void BtnDevConnect_Click(object sender, EventArgs e)
        {
            VideoInit(false, false);

            if (vlc != null && vlc.GetCurrentMedia() != null)
            {
                info.cam.data.IsStarted = true;
                //foreach(EventHandler evh in vlc.Media.StateChanged)
                //vlc.Media.StateChanged -= Media_StateChanged;
                vlc.GetCurrentMedia().StateChanged += GuiBase_StateChanged;
                vlc.EncounteredError += Vlc_EncounteredError;
                vlc.Buffering += Vlc_Buffering;
                vlc.PositionChanged += Vlc_PositionChanged;
                vlc.Play();
            }
            else
            {
                MessageBox.Show("Eroare la conexiune");
            }
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
                    vlc.Stop();
                    vlc.Dispose();
                    GC.Collect();
                    //ComboAddress_SelectionChangeCommitted(null, null);
                    VideoInit(false, false);
                    break;
                case Vlc.DotNet.Core.Interops.Signatures.MediaStates.Error:
                    info.cam.data.IsError = true;
                    break;
                default:
                    break;
            }


            if (vlc.State == Vlc.DotNet.Core.Interops.Signatures.MediaStates.Playing) //play vlc start
            {
                form.ControlShow(form.btnPlay, true);
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



    }
}
