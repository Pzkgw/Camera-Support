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

namespace GIShowCam.Gui
{
    class GuiBase
    {
        FormMain form;

        VlcControl vlc;




        Label labelPlaybackPosition;

        public GuiBase(FormMain formBase)
        {
            this.form = formBase;
        }

        internal void InitVideo(Panel panelVlc, Label labelPlaybackPosition)
        {
            labelPlaybackPosition.Text = string.Empty;
            this.labelPlaybackPosition = labelPlaybackPosition;
            

            vlc = new VlcControl();
            vlc.Dock = DockStyle.Fill;
            vlc.Parent = panelVlc;            
            vlc.PositionChanged += this.VlcControlOnPositionChanged;
            vlc.Enabled = false;
            vlc.EndReached += vlcControl_EndReached;
            //vlc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            

            PlayNextVideo();
            

        }


        private void PlayNextVideo()
        {
            
            vlc.Media = new LocationMedia(SessionInfo.host);
            vlc.Media.AddOption(SessionInfo.user);
            vlc.Media.AddOption(SessionInfo.pass);
            

            vlc.Play();

        }
        void vlcControl_EndReached(VlcControl sender, VlcEventArgs<EventArgs> e)
        {
            //listBoxPeUndeva.SelectedIndex += 1;
        }



        /// <summary>
        /// Event handler for the <see cref="VlcControl.PositionChanged"/> event. 
        /// Updates the label containing the playback position. 
        /// </summary>
        /// <param name="sender">Event sending <see cref="VlcControl"/>. </param>
        /// <param name="e">Event arguments, containing the current position. </param>
        private void VlcControlOnPositionChanged(VlcControl sender, VlcEventArgs<float> e)
        {
            labelPlaybackPosition.Text = "Pozitie(doar pentru video local) : " + (e.Data * 100).ToString("000") + " %";
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
