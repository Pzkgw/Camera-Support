using GIShowCam.Info;
using System;
using System.Windows.Forms;

namespace GIShowCam.Gui
{
    internal partial class GuiBase
    {

        /*

      media[i] = new Vlc.DotNet.Core.Medias.LocationMedia("rtsp://192.168.192.40:554/ch0_unicast_firststream");
       media[i].AddOption(":sout=#std{access=file,mux=ps,dst=d:\\tmp\\" + i.ToString() + ".mp4}");
       cap[i] = new Vlc.DotNet.Forms.VlcControl();
       cap[i].Play(media[i]);  

    */

        /*

          this.vlc = new Vlc.DotNet.Forms.VlcControl();
...
// in button click handler
MediaBase media = new LocationMedia("udp://@11.22.33.44:5555");
media.AddOption(@"--sout=#duplicate{dst=file{dst=c:\temp\foo.mpg},dst=display}");
vlc.Media = media;
vlc.Play();

*/
        private bool recordIsOn;

        Button btnSnapshot, btnRecord;
        internal void InitGuiRecord(GuiBase mainB, Button btnSnapshot, Button btnRecord)
        {
            this.btnRecord = btnRecord;
            this.btnSnapshot = btnSnapshot;

            BtnRecord_Click(this.btnRecord, null);


            btnSnapshot.Click += BtnSnapshot_Click;
            btnRecord.Click += BtnRecord_Click;
        }

        private void BtnRecord_Click(object sender, EventArgs e)
        {
            if (e != null)
                if (recordIsOn)
                {
                    //vlc.Media.AddOption("--color=random", Vlc.DotNet.Core.Interops.Signatures.LibVlc.Media.Option.Trusted);
                    recordIsOn = false;
                }
                else
                {
                    //vlc.Media.AddOption("--color=NIOrandom", Vlc.DotNet.Core.Interops.Signatures.LibVlc.Media.Option.Trusted);
                    Record("c:\\", "kk.mp4", 800);
                    recordIsOn = true;
                }


            btnRecord.Text = (recordIsOn ? "Stop" : "Start") + Environment.NewLine + "Recording";
        }
        string _finalFilename, _tempFilename, _tempPath = "C:\\_tmp";
        //bool _WasError, _IsFinished;
        int secondsToRecord;
        DateTime timeStarted, timeToComplete;

        //start a recording process
        public void Record(string url, string fileName, int durration)
        {
            //Persist parameters to instance fields
            _finalFilename = fileName;
            //Destination file name is initially a guid later to be moved and renamed upon completion
            //_tempPath was previously defined as "f:/MediaArchive"
            _tempFilename = System.IO.Path.Combine(_tempPath + Guid.NewGuid().ToString() + ".mp4");
            //_WasError = false; //indicate no error 
            //_IsFinished = false; //indicate successful completion of task
            //Timer used to control duration of recording
            this.secondsToRecord = durration * 60; //Want seconds
            timeStarted = DateTime.Now;
            timeToComplete = timeStarted.AddMinutes(durration);

            //Media to record
            //var media = new PathMedia(url);
            // Original options that worked well in previous version
            // string options = ":sout=#transcode{}:duplicate{dst=std{access=file,mux=mp4,dst=" + _tempFilename + "}}"; //works with display
            // tried to resolve issue with the following option removing the duplicate param
            string options = ":std{access=file,mux=mp4,dst=" + _tempFilename + "}"; //works with display 
                                                                                    //Verified the incoming parameters were correct
            System.Windows.Forms.MessageBox.Show(url);
            //Catch possible errors from vlc
            //--vlc.EncounteredError += vlc_EncounteredError;
            //Call owner thread manager indicating process started
            //--UpdateEvents(_finalFilename, durration, 0, false, false);
            //Setup the media options
            //vlc.Media.AddOption(options);
            //Setup the media MRL and start the process
            //vlc.Media = media;
            //Start the timer used to stop the recording after X minutes
            //--t1.Enabled = true;
        }


        private void BtnSnapshot_Click(object sender, EventArgs e)
        {
            //vlc.Media.
            vlc.TakeSnapshot(SessionInfo.snapshotDir);// , (uint)vlc.Width, (uint)vlc.Height
        }


    }
}
