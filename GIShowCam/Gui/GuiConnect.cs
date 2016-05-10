
using Declarations;
using Declarations.Events;
using Declarations.Media;
using Declarations.Players;
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

        IMediaPlayerFactory m_factory;
        IDiskPlayer m_player;
        IMedia m_media;

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

            /*
            if (vlc != null)
            {
                vlc.UnregisterEvents();
                //vlc.Stop(allowVlcMediaReinit);
            }*/


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
                form.RestartConnection();

                if (m_factory == null)
                {
                    m_factory = new MediaPlayerFactory(true);
                    m_player = m_factory.CreatePlayer<IDiskPlayer>();

                    m_player.Events.PlayerPositionChanged += new EventHandler<MediaPlayerPositionChanged>(Events_PlayerPositionChanged);
                    m_player.Events.TimeChanged += new EventHandler<MediaPlayerTimeChanged>(Events_TimeChanged);
                    m_player.Events.MediaEnded += new EventHandler(Events_MediaEnded);
                    m_player.Events.PlayerStopped += new EventHandler(Events_PlayerStopped);

                    m_player.WindowHandle = form.panelVlc.Handle;
                    //trackBar2.Value = m_player.Volume > 0 ? m_player.Volume : 0;

                    UISync.Init(this.form);


                    //(new System.Threading.Thread(delegate () { vlc.Parent = form.panelVlc; })).Start();

                    AddVlcEvents();
                }

                string path = info.host;

                if (path.Count(s => s == '.') > 2)
                {

                    if (!string.IsNullOrEmpty(info.user) && !string.IsNullOrEmpty(info.password) && ((path[5] == '/') || (path[6] == '/')))// http:// sau rtsp://
                    {
                        path = path.Insert(7, (info.user + ":" + info.password + "@"));
                    }

                    //vlc http://admin:1qaz@WSX@192.168.0.92/streaming/channels/2/httppreview --aspect-ratio=16:9
                }



                openMedia("rtsp://admin:admin@10.10.10.202:554/cam/realmonitor?channel=1&subtype=0");

                //(new System.Threading.Thread(delegate () 
                //{ openMedia("rtsp://admin:admin@10.10.10.202:554/cam/realmonitor?channel=1&subtype=0"); })).Start();

            }
            form.isOn = true;
        }

        private void openMedia(string addr)
        {
            m_media = m_factory.CreateMedia<IMedia>(addr);
            //"http://admin:1qaz@WSX@192.168.0.92/streaming/channels/1/httppreview");// textBox1.Text);
            m_media.Events.DurationChanged += new EventHandler<MediaDurationChange>(Events_DurationChanged);
            m_media.Events.StateChanged += new EventHandler<MediaStateChange>(Events_StateChanged);
            m_media.Events.ParsedChanged += new EventHandler<MediaParseChange>(Events_ParsedChanged);

            m_player.Open(m_media);
            m_media.Parse(true);

            m_player.Play();
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

            public static void Init(ISynchronizeInvoke sync)
            {
                Sync = sync;
            }

            public static void Execute(Action action)
            {
                Sync.BeginInvoke(action, null);
            }
        }


    }




}
