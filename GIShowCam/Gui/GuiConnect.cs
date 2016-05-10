﻿
using Declarations;
using Declarations.Events;
using Declarations.Media;
using Declarations.Players;
using GIShowCam.Info;
using Implementation;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


// -- Connect to camera --
namespace GIShowCam.Gui
{
    internal partial class GuiBase
    {
        private Point _vlcTop;
        private Size _vlcSize;

        internal void VideoInit(bool fullView, bool allowResize, bool allowVlcMediaReinit)
        {
            //form.isOn = false;
            /*
            if (vlc == null)
            {
                _vlcTop = form.panelVlc.Location;
                _vlcSize = form.panelVlc.Size;
            }*/

            
            if (m_media != null)
            {
                m_media.Dispose();
                m_media = null;
                //vlc.UnregisterEvents();
                //vlc.Stop(allowVlcMediaReinit);
            }


            if (allowResize)
                if (fullView)
                {
                    _vlcTop = form.panelVlc.Location;
                    _vlcSize = form.panelVlc.Size;
                    form.panelVlc.Location = new Point(0, 0);
                    form.panelVlc.Size = new Size(form.Width, form.Height);
                    form.panelVlc.Dock = DockStyle.Fill;
                    form.panelVlc.BringToFront();
                }
                else
                {
                    form.panelVlc.Location = _vlcTop;
                    form.panelVlc.Size = _vlcSize;
                    form.panelVlc.Dock = DockStyle.None;
                    //form.panelVlc.SendToBack();
                }

            if (allowVlcMediaReinit)
            {
                RestartConnection();


                openMedia(getPath());



                //UISync.Execute(() => m_player.WindowHandle = form.panelVlc.Handle);
                //(new System.Threading.Thread(delegate () {
                // openMedia("rtsp://admin:admin@10.10.10.202:554/cam/realmonitor?channel=1&subtype=0");
                //})).Start();
                //trackBar2.Value = m_player.Volume > 0 ? m_player.Volume : 0;
                //(new System.Threading.Thread(delegate () { vlc.Parent = form.panelVlc; })).Start();

                AddEventsPlayer();

                //} catch (Exception e) { MessageBox.Show(e.Message); }          



            }
            
        }

        private string getPath()
        {
            string path = info.host;

            if (path.Count(s => s == '.') > 2)
            {

                if (!string.IsNullOrEmpty(info.user) && !string.IsNullOrEmpty(info.password) && ((path[5] == '/') || (path[6] == '/')))// http:// sau rtsp://
                {
                    path = path.Insert(7, (info.user + ":" + info.password + "@"));
                }

                //vlc http://admin:1qaz@WSX@192.168.0.92/streaming/channels/2/httppreview --aspect-ratio=16:9
            }
            return path;
        }

        private void openMedia(string addr)
        {
            m_player.WindowHandle = new IntPtr(); // start pentru UISync
            m_media = m_factory.CreateMedia<IMedia>(addr);
            //"http://admin:1qaz@WSX@192.168.0.92/streaming/channels/1/httppreview");// textBox1.Text);


            m_player.Open(m_media);
            m_media.Parse(true);

            AddEventsMedia();

            info.SelectCamera(); // II'nd comboBox change select
            m_player.WindowHandle = form.panelVlc.Handle; // start pentru UISync



            //vlc.GetCurrentMedia().StateChanged += GuiBase_StateChanged;

            m_player.Play();

            UISync.on = true;
            info.cam.data.PropertyChanged += Data_PropertyChanged; // doar dupa conexiune de handle

            /*      --- OLD APPROACH
            if (vlc.initEndNeeded)
            {
                vlc.VlcLibDirectory = new DirectoryInfo(GetVlcLibLocation());
                vlc.VlcMediaplayerOptions = GetVlcOptions();
                vlc.EndInit();
                vlc.initEndNeeded = false;
                form.AddVlc(vlc);

            }

            vlc.SetMedia(path);
            //(new System.Threading.Thread(delegate () { uu(); })).Start();

            vlc.RegisterEvents();*/

        }

        /*
        /// <summary>
        /// Event chemat dupa ce o noua camera e conectata (MediaChanged)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void Vlc_MediaChanged(object sender, VlcMediaPlayerMediaChangedEventArgs e)
        {
            info.SelectCamera(); // comboBox change cheama al doilea select aici 

            info.cam.data.PropertyChanged += Data_PropertyChanged;
            vlc.GetCurrentMedia().StateChanged += GuiBase_StateChanged;

            vlc.Play();
        }*/

        private void ComboAddress_SelectionChangeCommitted(object sender, EventArgs e)
        {
            info.SelectCamera(form.comboAddress.SelectedIndex);

            form.txtDevUser.Text = info.user;
            form.txtDevPass.Text = info.password;
            form.comboAddress.Text = info.host;

            BtnDevConnect_Click(null, null);
        }

        private void BtnDevConnect_Click(object sender, EventArgs e)
        {
            VideoInit(false, false, true);
        }



        private class UISync
        {
            private static ISynchronizeInvoke Sync;
            internal static bool on = true;

            internal static void Init(ISynchronizeInvoke sync)
            {
                Sync = sync;
            }

            internal static void Execute(Action action)
            {
                if (on) Sync.BeginInvoke(action, null);
            }
        }


    }




}
