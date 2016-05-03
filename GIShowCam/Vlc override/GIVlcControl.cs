

using Vlc.DotNet.Forms;

namespace GIShowCam.Vlc_override
{
    class GIVlcControl : VlcControl
    {

        internal bool initEndNeeded;

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        /*
               internal void Unregister()
               {

                   if (myVlcMediaPlayer != null)
                   {
                       UnregisterEvents();
                       if (IsPlaying) Stop();
                       //myVlcMediaPlayer.Dispose();
                   }
                   //myVlcMediaPlayer = null;
                   //base.Dispose(disposing);
               }
               //base.Dispose(false);

               } */
    }
}
