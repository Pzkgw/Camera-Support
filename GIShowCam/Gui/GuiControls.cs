using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Core;
using Vlc.DotNet.Core.Medias;
using Vlc.DotNet.Forms;

namespace GIShowCam.Gui
{
    class GuiControls : GuiBase
    {
        Label labelPlaybackPosition;

        bool playIsOn;

        public GuiControls(GuiBase mainB, Button btnDevConnect, Button btnPlay, Label labelPlaybackPosition) : base(mainB)
        {
            vlc.PositionChanged += VlcControlOnPositionChanged;
            vlc.Playing += Vlc_Playing;

            vlc.EndReached += vlcControl_EndReached;           

            BtnPlay_Click(btnPlay, null);
            btnPlay.Click += BtnPlay_Click;
            BtnDevConnect_Click(btnDevConnect, null);
            btnDevConnect.Click += BtnDevConnect_Click;
        }

        private void BtnDevConnect_Click(object sender, EventArgs e)
        {
            if (vlc.IsPlaying) vlc.Stop();
            VideoPlay();
        }


        private void Media_StateChanged(MediaBase sender, VlcEventArgs<Vlc.DotNet.Core.Interops.Signatures.LibVlc.Media.States> e)
        {
            form.ControlTextUpdate(labelPlaybackPosition, "State: " + e.Data.ToString());
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


    }
}
