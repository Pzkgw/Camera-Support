using Declarations.Media;
using Declarations.Players;
using GIShowCam.Info;
using GIShowCam.Utils;
using Implementation;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;


// -- Connect to camera --
namespace GIShowCam.Gui
{
    internal partial class GuiBase
    {
        private Point _vlcTop;
        private Size _vlcSize;
        // todo: -- > mouseDown; record
        private void ToggleRunningMedia(bool on)
        {
            SessionInfo.Playing = false;

            if (on)
            {
                _mMedia = _mFactory.CreateMedia<IMedia>(GetPath());
                _mPlayer = _mFactory.CreatePlayer<IDiskPlayer>();

                _mPlayer.Open(_mMedia);
                //_mMedia.Parse(false);

                _info.NewCameraInfo();
                _info.Cam.Data.PropertyChanged += Data_PropertyChanged;

                RegisterPlayerEvents(true);
                RegisterMediaEvents(true);

                _mPlayer.WindowHandle = _form.panelVlc.Handle;

                UiSync.On = true;

                _mPlayer.Play();
            }
            else if (_mMedia != null)
            {
                _mPlayer.Stop();
                UiSync.On = false; // minus notify event send

                RegisterPlayerEvents(false);
                RegisterMediaEvents(false);

                _mMedia.Dispose();
                _mMedia = null;

                _mPlayer.Dispose();
                _mPlayer = null;

                //m_factory.VideoLanManager.DeleteMedia("m_media");
            }
        }

        internal void VideoInit(bool allowResize, bool fullView)
        {
            SessionInfo.Playing = false;

            if (_mFactory == null)
            {
                _mFactory = new MediaPlayerFactory(GetVlcOptions(),
                    SessionInfo.VlcDir, SessionInfo.Logger, true);
            }

            ToggleRunningMedia(false);


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
                    _vlcTop = _form.panelVlc.Location;
                    _vlcSize = _form.panelVlc.Size;
                    _form.panelVlc.Location = new Point(0, 0);
                    _form.panelVlc.Size = new Size(_form.Width, _form.Height);
                    _form.panelVlc.Dock = DockStyle.Fill;
                    _form.panelVlc.BringToFront();
                }
                else
                {
                    _form.panelVlc.Location = _vlcTop;
                    _form.panelVlc.Size = _vlcSize;
                    _form.panelVlc.Dock = DockStyle.None;
                    //form.panelVlc.SendToBack();
                }


            _logTimeLast = DateTime.MinValue; // pt mesajul de start connection

            ToggleRunningMedia(true);

            _info.Cam.Data.ViewSettings.AspectRatioDefault = Declarations.AspectRatioMode.Default;
            _form.btnRatio.Text = _info.Cam.Data.ViewSettings.AspectRatioMode.ToString();

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
        private void StartVlcReinit(bool byEnd)
        {
            LogEvent(@"Eroare la conexiune, repornire initializata");
            if (SessionInfo.ReinitCount != 0) return; // niciun alt thread

            if (byEnd)
            {
                _info.Cam.Data.IsEnded = true;

                TextUpdate(_form.lblVlcNotify,
                    " Vlc stopped and re-initialization started ... ", false, false, false);
            }
            else
            {
                _info.Cam.Data.IsError = true;
            }

            VlcReinit();
        }

        private void VlcReinit()
        {
            while (true)
            {
                ToggleRunningMedia(false);
                Thread.Sleep(4);
                GC.Collect();
                Thread.Sleep(4);
                ToggleRunningMedia(true);

                if (_info.Cam.Data.IsError)
                {
                    ++SessionInfo.ReinitCount;
                    if (SessionInfo.ReinitCount < 4) continue;
                }

                //(new System.Threading.Thread(delegate () { VideoInit(false,false,true); })).Start(); 

                SessionInfo.ReinitCount = 0;
                break;
            }
        }



        private string GetPath()
        {
            var path = _info.Host;

            if (path.Count(s => s == '.') <= 2) return path;

            if (!string.IsNullOrEmpty(_info.User) &&
                !string.IsNullOrEmpty(_info.Password) &&
                ((path[5] == '/') || (path[6] == '/')))// http:// sau rtsp://
            {
                path = path.Insert(7, (_info.User + ':' + _info.Password + '@'));
            }

            //vlc http://admin:1qaz@WSX@192.168.0.92/streaming/channels/2/httppreview --aspect-ratio=16:9
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
            _info.UpdateAfterIndexChange(_form.comboAddress.SelectedIndex);
            DeviceTextBoxesUpdate(true);
            BtnDevConnect_Click(null, null);
        }

        private void BtnDevConnect_Click(object sender, EventArgs e)
        {
            //string[] initMediaOptions = GetVlcMediaOptions();
            VideoInit(false, false);//, GetVlcMediaOptions()
            _form.btnPlay.Text = @"Stop";
        }

    }


}
