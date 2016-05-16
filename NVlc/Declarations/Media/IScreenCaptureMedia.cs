using System.Drawing;

namespace Declarations.Media
{
    /// <summary>
    /// Represents media captured from screen or a part of it.
    /// </summary>
    public interface IScreenCaptureMedia : IMedia
   {
      /// <summary>
      /// Capture area of the screen.
      /// </summary>
      Rectangle CaptureArea { get; set; }

      /// <summary>
      /// Gets or sets the frame rate of the capture.
      /// </summary>
      int FPS { get; set; }

      /// <summary>
      /// Gets or sets value indication whether to include the mouse cursor in the captured frame.
      /// </summary>
      bool FollowMouse { get; set; }

      /// <summary>
      /// Gets or sets full path of the file (PNG) containing cursor icon.
      /// </summary>
      string CursorFile { get; set; }
   }
}
