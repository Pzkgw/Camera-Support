using System.Drawing;

namespace Declarations.Media
{
    /// <summary>
    /// Enables raw video frames input into VLC engine (based on invmem access module)
    /// </summary>
    public interface IVideoInputMedia : IMedia
   {
      /// <summary>
      /// Adds frame to the video stream.
      /// </summary>
      /// <param name="frame"></param>
      void AddFrame(Bitmap frame);

      /// <summary>
      /// Sets bitmap format for the video frames.
      /// </summary>
      /// <param name="format"></param>
      void SetFormat(BitmapFormat format);
   }
}
