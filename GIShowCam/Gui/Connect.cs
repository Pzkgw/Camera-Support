using Declarations.Media;
using Declarations.Players;
using GIShowCam.Info;
using GIShowCam.Utils;
using Implementation;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


// -- Connect to camera --
namespace GIShowCam.Gui
{
    internal partial class GuiBase
    {
        private Point _vlcTop;
        private Size _vlcSize;


        private void ToggleRunningMedia(bool on)
        {
            if (on)
            {
                m_media = m_factory.CreateMedia<IMedia>(getPath());
                m_player = m_factory.CreatePlayer<IDiskPlayer>();

                m_player.Open(m_media);
                m_media.Parse(false);

                info.NewCameraInfo();
                info.cam.data.PropertyChanged += Data_PropertyChanged; // => doar dupa conexiune de handle

                RegisterPlayerEvents(true);
                RegisterMediaEvents(true);

                m_player.WindowHandle = form.panelVlc.Handle;

                UISync.on = true;

                m_player.Play();
            }

            else

            if (m_media != null)
            {
                m_player.Stop();
                UISync.on = false;// fara notify event send

                RegisterPlayerEvents(false);
                RegisterMediaEvents(false);

                m_media.Dispose();
                m_media = null;

                m_player.Dispose();
                m_player = null;

                //m_factory.VideoLanManager.DeleteMedia("m_media");
            }
        }

        internal void VideoInit(bool allowResize, bool fullView)
        {
            if (m_factory == null)
            {
                m_factory = new MediaPlayerFactory(GetVlcOptions(),
                    SessionInfo.vlcDir, SessionInfo.logger, true);
            }

            ToggleRunningMedia(false);

            SessionInfo.playing = false;
            //form.isOn = false;
            /*
            if (vlc == null)
            {
                _vlcTop = form.panelVlc.Location;
                _vlcSize = form.panelVlc.Size;
            }*/



            // pentru fullscreen on/off, allowResize ::--> async
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


            _logTimeLast = DateTime.MinValue; // pt mesajul de start connection

            ToggleRunningMedia(true);

            info.cam.data.viewSettings.aspectRatioDefault = Declarations.AspectRatioMode.Default;
            form.btnRatio.Text = info.cam.data.viewSettings.aspectRatioMode.ToString();

            /*
            info.cam.data.viewSettings.aspectRatioDefault = Declarations.AspectRatioMode.Default;
            m_player.AspectRatio = Declarations.AspectRatioMode.Default;
            form.btnRatio.Text = info.cam.data.viewSettings.aspectRatioMode.ToString();*/


            //UISync.Execute(() => m_player.WindowHandle = form.panelVlc.Handle);
            //(new System.Threading.Thread(delegate () {
            // openMedia("rtsp://admin:admin@10.10.10.202:554/cam/realmonitor?channel=1&subtype=0");
            //})).Start();

            //(new System.Threading.Thread(delegate () { vlc.Parent = form.panelVlc; })).Start();

            //} catch (Exception e) { MessageBox.Show(e.Message); }

        }

        /// <summary>
        /// Dupa media-stop sesizat de media\events\MediaStateChange(event extern),
        /// urmeaza un pointer spre functia VlcReinit()
        /// </summary>
        /// <returns></returns>
        private void VlcReinit()
        {
            ToggleRunningMedia(false);
            ToggleRunningMedia(true);

            GC.Collect();

            if (info.cam.data.IsError)
                VlcReinit();

            //(new System.Threading.Thread(delegate () { VideoInit(false,false,true); })).Start(); 

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
            info.UpdateAfterIndexChange(form.comboAddress.SelectedIndex);
            DeviceTextBoxesUpdate(true);
            BtnDevConnect_Click(null, null);
        }

        private void BtnDevConnect_Click(object sender, EventArgs e)
        {
            //string[] initMediaOptions = GetVlcMediaOptions();
            VideoInit(false, false);//, GetVlcMediaOptions()
            form.btnPlay.Text = "Stop";
        }


    }


}
