

using System.Windows.Forms;
using Vlc.DotNet.Forms;

namespace GIShowCam.Vlc_override
{
    class GIVlcControl : VlcControl
    {

        internal bool initEndNeeded;

        internal void MpPlay()
        {
            //(new System.Threading.Thread(delegate () { Play(); })).Start();
            Play();
        }

        internal void MpStop(bool preDel)
        {
            
            //(new System.Threading.Thread(delegate () { Stop(); })).Start();
            Stop();
            if (preDel) GetCurrentMedia().Dispose();
        }

        internal void MpPause()
        {
            //(new System.Threading.Thread(delegate () { Pause(); })).Start();
            Pause();
        }

        /*
        protected override void OnPaint(PaintEventArgs e)
        {
            OnPaint(e);
        }*/

    }
}
