using System.ComponentModel;

namespace GIShowCam.Info
{

    class DeviceInfo
    {
        private bool[]
            act = new bool[8],
            inter = new bool[2];

        public event PropertyChangedEventHandler PropertyChanged;

        internal DeviceInfo()
        {
            int i = 0;
            for (; i < act.Length; i++) act[i] = false;
            for (i = 0; i < inter.Length; i++) inter[i] = false;
        }

        #region Stari Video

        // Start, Open, Buffering
        // Playing, Paused, Stopped
        // Ended, Error 

        internal bool IsStarted//0000
        {
            set
            {
                act[0] = value;
                OnPropertyChanged("IsStarted");
            }
            get
            {
                return act[0];
            }
        }

        internal bool IsOpening//0001
        {
            set
            {
                act[1] = value;
                OnPropertyChanged("IsOpening");

            }
            get
            {
                return act[1];
            }
        }

        internal bool IsBuffering//0010
        {
            set
            {
                act[2] = value;
                OnPropertyChanged("IsBuffering");

            }
            get
            {
                return act[2];
            }
        }

        internal bool IsPlaying//0011
        {
            set
            {
                act[3] = value;
                OnPropertyChanged("IsPlaying");

            }
            get
            {
                return act[3];
            }
        }

        internal bool IsPaused//0100
        {
            set
            {
                act[4] = value;
                OnPropertyChanged("IsPaused");

            }
            get
            {
                return act[4];
            }
        }

        internal bool IsStopped//0101
        {
            set
            {
                act[5] = value;
                OnPropertyChanged("IsStopped");
            }
            get
            {
                return act[5];
            }
        }

        internal bool IsEnded//0110
        {
            set
            {
                act[6] = value;
                OnPropertyChanged("IsEnded");
            }
            get
            {
                return act[6];
            }
        }



        internal bool IsError//0111
        {
            set
            {
                act[7] = value;
                OnPropertyChanged("IsError");
            }
            get
            {
                return act[7];
            }
        }

        #endregion


        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
