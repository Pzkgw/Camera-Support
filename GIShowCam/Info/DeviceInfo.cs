using Declarations;
using System.ComponentModel;

namespace GIShowCam.Info
{
    internal struct ViewSettings
    {
        internal AspectRatioMode AspectRatioDefault, AspectRatioMode;
    }

    internal class DeviceInfo : INotifyPropertyChanged
    {
        private readonly bool[] _act = new bool[10];

        internal int ImgCount;

        internal ViewSettings ViewSettings;


        public event PropertyChangedEventHandler PropertyChanged;

        internal DeviceInfo()
        {
            ImgCount = 0;
            ViewSettings.AspectRatioMode = AspectRatioMode.Mode2;
            ViewSettings.AspectRatioDefault = AspectRatioMode.Default;

            int i = 0;
            for (; i < _act.Length; i++) _act[i] = false;
        }


        #region Stari Video

        // Start, Open, Buffering
        // Playing, Paused, Stopped
        // Ended, Error 

        internal bool IsStarted//0000
        {
            set
            {
                _act[0] = value;
                if (value) OnPropertyChanged(" Unused ");
            }
            get
            {
                return _act[0];
            }
        }

        internal bool IsOpening//0001
        {
            set
            {
                _act[1] = value;
                if (value) OnPropertyChanged("Open: Porn-ire conexiune ");
            }
            get
            {
                return _act[1];
            }
        }

        internal bool IsBuffering//0010
        {
            set
            {
                _act[2] = value;
                if (value) OnPropertyChanged("Buffering ... ");

            }
            get
            {
                return _act[2];
            }
        }

        internal bool IsPlaying//0011
        {
            set
            {
                _act[3] = value;
                if (value) OnPropertyChanged("Playing: \"Filmul ruleaza\" ");

            }
            get
            {
                return _act[3];
            }
        }

        internal bool IsPaused//0100
        {
            set
            {
                _act[4] = value;
                if (value) OnPropertyChanged("Pause: Pauza de masa ");

            }
            get
            {
                return _act[4];
            }
        }

        internal bool IsStopped//0101
        {
            set
            {
                _act[5] = value;
                if (value) OnPropertyChanged("Stop: Conexiune oprita temporar ");
            }
            get
            {
                return _act[5];
            }
        }

        internal bool IsEnded//0110
        {
            set
            {
                _act[6] = value;
                if (value) OnPropertyChanged("End: Conexiune terminata ");
            }
            get
            {
                return _act[6];
            }
        }



        internal bool IsError//0111
        {
            set
            {
                _act[7] = value;
                if (value) OnPropertyChanged("Error: Greseala imensa ");
            }
            get
            {
                return _act[7];
            }
        }

        internal bool IsVideoComplete//1000
        {
            set
            {
                _act[8] = value;
                if (value) OnPropertyChanged("VideoComplete: Conexiunea trimite imagini ");
            }
            get
            {
                return _act[8];
            }
        }

        internal bool MediaChanged
        {
            set
            {
                _act[9] = value;
                if (value) OnPropertyChanged("MediaChange: Schimbare de camera ");
            }
            get
            {
                return _act[9];
            }
        }

        #endregion

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }



    }
}
