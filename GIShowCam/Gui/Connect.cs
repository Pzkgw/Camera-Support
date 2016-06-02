using Declarations.Media;
using Declarations.Players;
using GIShowCam.Info;
using Implementation;
using System;
using System.Linq;
using System.Windows.Forms;


// -- Connect to camera --
namespace GIShowCam.Gui
{
    internal partial class GuiBase
    {
        //private Point _vlcTop;
        //private Size _vlcSize;

        // todo: -- > mouseDown; record
        private void ToggleRunningMedia(bool on)
        {
            //CLogger.VideoOnPlay = false;
            if (on)
            {

                _mPlayer = _mFactory.CreatePlayer<IDiskPlayer>();

                _mPlayer.Open(_mFactory, GetPath());
                _mMedia = _mPlayer.CurrentMedia;
                //_mMedia.Parse(false);

                if (!SessionInfo.FullScreen)
                {
                    _info.NewCameraInfo();
                    _info.Cam.Data.PropertyChanged += Data_PropertyChanged;

                    RegisterPlayerEvents(true);                    
                }

                ToggleDrawing(true);

                _mPlayer.Play();

                RegisterMediaEvents(true);
            }
            else if (_mMedia != null)
            {
                _mPlayer.Stop();

                if (!SessionInfo.FullScreen)
                {
                    RegisterPlayerEvents(false);
                    RegisterMediaEvents(false);
                }

                ToggleDrawing(false);

                _mMedia.Dispose();
                _mMedia = null;

                _mPlayer.Dispose();
                _mPlayer = null;

                GC.Collect();
                GC.SuppressFinalize(_form);
                GC.WaitForPendingFinalizers();

                //m_factory.VideoLanManager.DeleteMedia("m_media");
            }
        }

        internal void VideoInit(bool allowResize)
        {

            if (_mFactory == null)
            {
                _mFactory = new MediaPlayerFactory(GetVlcOptions(),
                    SessionInfo.VlcDir, true, SessionInfo.Logger);
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
            {
                if (SessionInfo.FullScreen)
                {
                    _form.panelVlc.Dock = DockStyle.Fill;
                    _form.WindowState = FormWindowState.Maximized;
                    _form.FormBorderStyle = FormBorderStyle.None;
                    _form.TopMost = true;
                    //FullScreenApi.SetWinFullScreen(_form.Handle);
                }
                /*
                else
                    if (SessionInfo.FullVideo)
                {
                    _vlcTop = _form.panelVlc.Location;
                    _vlcSize = _form.panelVlc.Size;
                    _form.panelVlc.Location = new Point(0, 0);
                    _form.panelVlc.Size = new Size(_form.Width, _form.Height);
                    _form.panelVlc.Dock = DockStyle.Fill;
                    //_form.panelVlc.BringToFront();
                }
                else
                {
                    _form.panelVlc.Location = _vlcTop;
                    _form.panelVlc.Size = _vlcSize;
                    _form.panelVlc.Dock = DockStyle.None;
                    //form.panelVlc.SendToBack();
                }
                */
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

            _mFactory.VideoLanManager.Events.MediaInstanceError += Events_MediaInstanceError;

        }

        private void Events_MediaInstanceError(object sender, Declarations.VLM.VlmEvent e)
        {
            
        }

        /// <summary>
        /// Dupa media-stop sesizat de media\events\MediaStateChange(event extern),
        /// urmeaza un pointer spre functia VlcReinit()
        /// </summary>
        /// <returns></returns>
        private void StartVlcReinit(bool byEnd)
        {            
            if (_info.ReinitCount != 0) return; // niciun alt thread

            if (!SessionInfo.FullScreen)
                LogEvent(@"Eroare la conexiune, repornire initializata");

            if (byEnd)
            {
                _info.Cam.Data.IsEnded = true;
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

                //Thread.Sleep(8);

                ToggleRunningMedia(true);

                if (_info.Cam.Data.IsError)
                {
                    ++_info.ReinitCount;
                    if (_info.ReinitCount < 4) continue;
                }

                //(new System.Threading.Thread(delegate () { VideoInit(false,false,true); })).Start(); 

                _info.ReinitCount = 0;
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
            VideoInit(false);//, GetVlcMediaOptions()
            _form.btnPlay.Text = @"Stop";
        }

    }


}
