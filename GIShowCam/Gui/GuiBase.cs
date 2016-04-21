using GIShowCam;
using GIShowCam.Info;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Forms;
using Vlc.DotNet.Core;
using Vlc.DotNet.Core.Medias;
using System.Windows.Threading;

namespace GIShowCam.Gui
{
    class GuiBase
    {
        FormMain form;

        VlcControl vlc;

        Label labelPlaybackPosition;
        TextBox txtDevUrl, txtDevUser, txtDevPass;

        bool playIsOn;

        public GuiBase(FormMain formBase)
        {
            this.form = formBase;            
        }

        #region Camera Video

        internal void InitVideoControl(Panel panelVlc, Label labelPlaybackPosition)
        {
            labelPlaybackPosition.Text = string.Empty;
            this.labelPlaybackPosition = labelPlaybackPosition;


            vlc = new VlcControl();
            vlc.Dock = DockStyle.Fill;
            vlc.Enabled = false;
            //vlc.ImeMode = System.Windows.Forms.ImeMode.NoControl;

            vlc.PositionChanged += VlcControlOnPositionChanged;
            vlc.Playing += Vlc_Playing;

            vlc.EndReached += vlcControl_EndReached;

            vlc.Parent = panelVlc;

            




        }

        private void Media_StateChanged(MediaBase sender, VlcEventArgs<Vlc.DotNet.Core.Interops.Signatures.LibVlc.Media.States> e)
        {
            form.ControlTextUpdate(labelPlaybackPosition, "State: " + e.Data.ToString());
        }

        private void Vlc_Playing(VlcControl sender, VlcEventArgs<EventArgs> e)
        {
            if (!playIsOn && vlc.IsPlaying) playIsOn = true;
        }

        private void PlayNextVideo()
        {
            if (vlc.Media != null) vlc.Media.Dispose();

            if (SessionInfo.host.Count(s => s == '.') > 2)
            {
                string path = SessionInfo.host, util = SessionInfo.user + ":" + SessionInfo.pass + "@";
                
                if(path.Contains("rtsp://")&& SessionInfo.user.Length>0)
                {
                    path = path.Insert(7, util);
                }

                LocationMedia media = new LocationMedia(path);
                //media.AddOption("vvv");                

                vlc.Media = media;
                vlc.Media.StateChanged += Media_StateChanged;

            }
            else
            {
                vlc.Media = new PathMedia(SessionInfo.host);
            }            

            vlc.Play();
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

        #endregion Camera Video

        #region Device Info


        internal void InitDeviceControl(TextBox txtDevUrl, TextBox txtDevUser, TextBox txtDevPass, Button btnDevConnect)
        {
            txtDevUrl.Text = SessionInfo.host;
            txtDevUser.Text = SessionInfo.user;
            txtDevPass.Text = SessionInfo.pass;

            this.txtDevUrl = txtDevUrl;
            this.txtDevUser = txtDevUser;
            this.txtDevPass = txtDevPass;

            BtnDevConnect_Click(btnDevConnect, null);
            btnDevConnect.Click += BtnDevConnect_Click;
        }

        private void BtnDevConnect_Click(object sender, EventArgs e)
        {
            if (e != null)
            {
                SessionInfo.host = txtDevUrl.Text;
                SessionInfo.user = txtDevUser.Text;
                SessionInfo.pass = txtDevPass.Text;
            }

            if (vlc.IsPlaying) vlc.Stop();
            PlayNextVideo();            
        }

        #endregion Device Info

        #region Additional Controls

        internal void InitAdditionalControls(Button btnPlay)
        {
            BtnPlay_Click(btnPlay, null);
            btnPlay.Click += BtnPlay_Click;
        }

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

        internal void CleanUp()
        {
            if (vlc.IsPlaying) vlc.Stop();
            if (vlc.Media != null) vlc.Media.Dispose();
            if (vlc != null) vlc.Dispose();
        }
        


    }
}
