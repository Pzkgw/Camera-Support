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

        Button btnPlay, btnSnapshot, btnRecord;

        bool playIsOn, recordIsOn;

        public GuiControls(GuiBase mainB, Button btnDevConnect,
            TextBox txtDevAddress, TextBox txtDevUser, TextBox txtDevPass, 
            TextBox textBoxWidthF, TextBox textBoxHeightF,
            Button btnPlay, Button btnSnapshot, Button btnRecord, Label lblVlcNotify) : base(mainB)
        {

            txtDevAddress.Text = SessionInfo.host;
            txtDevUser.Text = SessionInfo.user;
            txtDevPass.Text = SessionInfo.pass;

            this.lblVlcNotifications = lblVlcNotify;
            this.btnRecord = btnRecord;
            this.btnSnapshot = btnSnapshot;
            this.btnPlay = btnPlay;
            this.txtDevAddress = txtDevAddress;
            this.txtDevUser = txtDevUser;
            this.txtDevPass = txtDevPass;

            vlc.Playing += Vlc_Playing;            
            vlc.EndReached += vlcControl_EndReached;
            vlc.PositionChanged += VlcControlOnPositionChanged;

            BtnDevConnect_Click(btnDevConnect, null);
            BtnRecord_Click(btnRecord, null);

            btnDevConnect.Click += BtnDevConnect_Click;            
            btnSnapshot.Click += BtnSnapshot_Click;            
            btnRecord.Click += BtnRecord_Click;
            btnPlay.Click += BtnPlay_Click;


            //textbox changed events:
            AddDevConnectTextEvents();
            textBoxWidthF.TextChanged += TextBoxWidthF_TextChanged;
            textBoxHeightF.TextChanged += textBoxHeightF_TextChanged;
        }

        private void TextBoxWidthF_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBoxHeightF_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void BtnRecord_Click(object sender, EventArgs e)
        {
            if (e != null)
                if (recordIsOn)
                {
                    //vlc.Media.AddOption("--color=random", Vlc.DotNet.Core.Interops.Signatures.LibVlc.Media.Option.Trusted);
                    recordIsOn = false;
                }
                else
                {
                    //vlc.Media.AddOption("--color=NIOrandom", Vlc.DotNet.Core.Interops.Signatures.LibVlc.Media.Option.Trusted);
                    recordIsOn = true;
                }


            btnRecord.Text = recordIsOn ? "Start" : "Stop" + Environment.NewLine + "Record";
        }
        /*
        //Called to start a recording process
        //Called to start a recording process
        public void Record(string url, string fileName, int durration)
        {
            //Persist parameters to instance fields
            _finalFilename = fileName;
            //Destination file name is initially a guid later to be moved and renamed upon completion
            //_tempPath was previously defined as "f:/MediaArchive"
            _tempFilename = System.IO.Path.Combine(_tempPath + Guid.NewGuid().ToString() + ".mp4");
            _WasError = false; //indicate no error 
            _IsFinished = false; //indicate successful completion of task
                                 //Timer used to control duration of recording
            this.secondsToRecord = durration * 60; //Want seconds
            timeStarted = DateTime.Now;
            timeToComplete = timeStarted.AddMinutes(durration);

            //Media to record
            var media = new PathMedia(url);
            // Original options that worked well in previous version
            // string options = ":sout=#transcode{}:duplicate{dst=std{access=file,mux=mp4,dst=" + _tempFilename + "}}"; //works with display
            // tried to resolve issue with the following option removing the duplicate param
            string options = ":std{access=file,mux=mp4,dst=" + _tempFilename + "}"; //works with display 
                                                                                    //Verified the incoming parameters were correct
            System.Windows.Forms.MessageBox.Show(url);
            //Catch possible errors from vlc
            vlc.EncounteredError += vlc_EncounteredError;
            //Call owner thread manager indicating process started
            UpdateEvents(_finalFilename, durration, 0, false, false);
            //Setup the media options
            media.AddOption(options);
            //Setup the media MRL and start the process
            vlc.Media = media;
            //Start the timer used to stop the recording after X minutes
            t1.Enabled = true;
        }
        */

        private void BtnSnapshot_Click(object sender, EventArgs e)
        {
            //vlc.Media.
            vlc.TakeSnapshot(SessionInfo.snapshotDir, (uint)vlc.Width, (uint)vlc.Height);
        }

        private void BtnDevConnect_Click(object sender, EventArgs e)
        {
            VideoPlayInit();
            if (vlc != null && vlc.Media != null)
            {
                vlc.Media.StateChanged += Media_StateChanged;
                //vlc.NextFrame();
                vlc.Play(vlc.Media);
            }
        }

        private void Media_StateChanged(MediaBase sender, VlcEventArgs<Vlc.DotNet.Core.Interops.Signatures.LibVlc.Media.States> e)
        {
            //form.ControlTextUpdate(lblVlcNotifications, "State: " + e.Data.ToString());
            form.Log("Connection state: " + e.Data.ToString());
            //form.ControlTextUpdate(lblVlcNotifications, e.Data.ToString());
        }

        private void Vlc_Playing(VlcControl sender, VlcEventArgs<EventArgs> e)
        {

        }


        void vlcControl_EndReached(VlcControl sender, VlcEventArgs<EventArgs> e)
        {
            vlc.Stop();
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
            //form.ControlTextUpdate(lblVlcNotifications, "Pozitie(doar pentru video local) : " + (e.Data * 100).ToString("000") + " %");
            //form.ControlTextUpdate(lblVlcNotifications, "FPS: " + vlc.FPS);
            form.ControlTextUpdate(lblVlcNotifications,
                "State: " + vlc.State +
                " & DecodedVideo: " + vlc.Media.Statistics.DecodedVideo +
                " & DisplayedPictures: " + vlc.Media.Statistics.DisplayedPictures +
                " & SentBytes: " + vlc.Media.Statistics.SentBytes);

            if (!playIsOn && vlc.IsPlaying) //play vlc start
            {
                form.ControlShow(btnPlay, true);
                form.ControlShow(btnSnapshot, true);
                BtnPlay_Click(null, null);

                //form.Log(null);
            }
        }

        #region Additional Controls



        private void BtnPlay_Click(object sender, EventArgs e)
        {
            if (playIsOn)
            {
                if (vlc.IsPlaying) vlc.Stop();
                form.ControlShow(btnRecord, false);
                playIsOn = false;
            }
            else
            {
                if (!vlc.IsPlaying) vlc.Play();
                form.ControlShow(btnRecord, true);                
                playIsOn = true;
            }

            //((Button)sender)
            btnPlay.Text = playIsOn ? "Stop" : "Play";
            //((Button)sender).Update();
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
