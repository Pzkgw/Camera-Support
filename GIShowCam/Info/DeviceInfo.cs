using System;
using System.ComponentModel;

namespace GIShowCam.Info
{

    class DeviceInfo : INotifyPropertyChanged
    {
        private bool[]
            act = new bool[10];

        internal int imgCount;
        

        public event PropertyChangedEventHandler PropertyChanged;

        internal DeviceInfo()
        {
            Start();
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
                if (value) OnPropertyChanged(" Start ");
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
                if (value) OnPropertyChanged(" Conexiune deschisa ");
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
                if (value) OnPropertyChanged(" Buffering de conexiune ");

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
                if (value) OnPropertyChanged(" Margareta Nistor: \"Filmul ruleaza\" ");

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
                if (value) OnPropertyChanged(" Pauza de masa ");

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
                if(value) OnPropertyChanged(" Conexiune oprita temporar ");
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
                if (value) OnPropertyChanged(" Conexiune terminata ");
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
                if (value) OnPropertyChanged(" Greseala imensa ");
            }
            get
            {
                return act[7];
            }
        }

        internal bool IsVideoComplete//1000
        {
            set
            {
                act[8] = value;
                if (value) OnPropertyChanged(" Conexiunea trimite imagini ");
            }
            get
            {
                return act[8];
            }
        }

        internal bool MediaChanged
        {
            set
            {
                act[9] = value;
                if (value) OnPropertyChanged(" Schimbare de camera ");
            }
            get
            {
                return act[9];
            }
        }

        #endregion

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        internal void Start()
        {
            imgCount = 0;

            int i = 0;
            for (; i < act.Length; i++) act[i] = false;

            
        }
    }
}
