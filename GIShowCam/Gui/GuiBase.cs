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

        private void Media_StateChanged1(MediaBase sender, VlcEventArgs<Vlc.DotNet.Core.Interops.Signatures.LibVlc.Media.States> e)
        {
            form.ControlTextUpdate(labelPlaybackPosition, e.Data.ToString());
        }

        private void Vlc_Playing(VlcControl sender, VlcEventArgs<EventArgs> e)
        {
            if (!playIsOn && vlc.IsPlaying) playIsOn = true;
        }

        private void PlayNextVideo()
        {
            if (vlc.Media != null) vlc.Media.Dispose();

            if (SessionInfo.host.Count(f => f == '.') > 2)
            {
                LocationMedia media = new LocationMedia(SessionInfo.host);
                media.AddOption(SessionInfo.user);//vlc.Media.AddOption(SessionInfo.user);
                media.AddOption(SessionInfo.pass);//vlc.Media.AddOption(SessionInfo.pass);
                media.StateChanged += Media_StateChanged1;


                vlc.Media = media;
                
                
                
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





/*
Vlc.DotNet.Core.VlcMedia media = new Vlc.DotNet.Core.VlcMedia(@"rtsp://172.16.22.61:554/live");

public void SetMedia(FileInfo file, params string[] options);
public void SetMedia(string mrl, params string[] options);
public void SetMedia(Uri file, params string[] options);




Uri uri = new Uri(SessionInfo.host);
FileInfo fi = new FileInfo(SessionInfo.host);

DirectoryInfo di = new DirectoryInfo("c:\\");//SessionInfo.vlcPlugins);


vlc = new VlcControl();

panel.Controls.Add(vlc);

vlc.BackColor = System.Drawing.Color.Black;
//player.ImeMode = System.Windows.Forms.ImeMode.NoControl;
vlc.Location = new System.Drawing.Point(0, 0);
vlc.Size = new System.Drawing.Size(panel.Width, panel.Height);
vlc.Name = "test";

vlc.Dock = DockStyle.Fill;

//Vlc.DotNet.Core.Medias.LocationMedia[] media;

///vlc.SetMedia(new System.IO.FileInfo("c:\\2016-4-18-18-4-15.mpeg4"));
vlc.Play(new Uri("2016-4-18-18-4-15.mpeg4"));//uri, us, pa 

//VlcMediaPlayer mk = new VlcMediaPlayer(di);



//LibVLCLibrary library = LibVLCLibrary.Load(null);

//

//Vlc.DotNet.Core.Interops.VlcManager op = Vlc.DotNet.Core.Interops.VlcManager.GetInstance(di);

//player..PluginsPath = @"C:\Program Files (x86)\VideoLAN\VLC\plugins\";


//op.CreateNewInstance(new string[] { "root", "cavi123,." });
//op.CreateMediaPlayerFromMedia(op.CreateNewMediaFromPath("c:\\2016-4-18-18-4-15.mpeg4"));


//  //  myVlcMediaPlayer.SetMedia(file, options);

//if (myVlcMediaPlayer != null)    myVlcMediaPlayer.SetMedia(uri, options);    Play();



*/
