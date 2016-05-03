
using System;
using System.IO;
using System.Linq;
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
                info.cam.data.Start();

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

        protected void VideoPlayInit()
        {

            form.Restart();

            if (vlc == null)
            {
                InitVlcStart();
                vlc.Parent = form.panelVlc;
                vlc.initEndNeeded = true;
            }
            else
            {

                // if (vlc.GetCurrentMedia() != null){    vlc.GetCurrentMedia().Dispose();    vlc.Stop();    vlc.Unregister(); } 
                //vlc.Dispose();
                //vlc = null;
                vlc.Stop();
            }

            string path = info.host;

            if (path.Count(s => s == '.') > 2)
            {

                if (!string.IsNullOrEmpty(info.user) && !string.IsNullOrEmpty(info.password) && ((path[5] == '/') || (path[6] == '/')))// http:// sau rtsp://
                {
                    path = path.Insert(7, (info.user + ":" + info.password + "@"));
                }

                //vlc rtsp://10.10.10.78/axis-media/media.amp --rtsp-user=root --rtsp-pwd=cavi123,.
                //LocationMedia media = new LocationMedia(path);
                //media.AddOption("no-snapshot-preview");
                //media.AddOption("-vvv");//optional : "Verbose verbose verbose". Verbose output
                //media.AddOption("–-aspect-ratio=4:3");
                //media.AddOption("--grayscale");

                //VlcContext.StartupOptions.AddOption("--width=" + panelVlc.Width);
                //VlcContext.StartupOptions.AddOption("--height=" + panelVlc.Height);
                //VlcContext.StartupOptions.AddOption("--aspect-ratio=1:9");
                //VlcContext.StartupOptions.AddOption("--autocrop");--crop-geometry "180 x 120 + 0 + 0"
                //VlcContext.StartupOptions.AddOption("--crop-geometry \"" + panelVlc.Width + "x" + panelVlc.Height + " + 0 + 0\"");--aspect-ratio=16:9

                //vlc http://admin:1qaz@WSX@192.168.0.92/streaming/channels/2/httppreview --aspect-ratio=16:9

                //vlc.GetCurrentMedia().ParseAsync();
            }

            if (vlc.initEndNeeded)
            {
                InitVlcEnd();
                vlc.initEndNeeded = false;
            }
            vlc.SetMedia(path);

        }

    }
}
