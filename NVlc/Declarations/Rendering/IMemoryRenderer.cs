using System.Drawing;

namespace Declarations
{
    /// <summary>
    /// Enables custom processing of video frames.
    /// </summary>
    public interface IMemoryRenderer : IRenderer
    {
        /// <summary>
        /// Sets the callback which invoked when new frame should be displayed
        /// </summary>
        /// <param name="callback">Callback method</param>
        /// <remarks>The frame will be auto-disposed after callback invokation.</remarks>
        void SetCallback(NewFrameEventHandler callback);

        /// <summary>
        /// Gets the latest video frame that was displayed.
        /// </summary>
        Bitmap CurrentFrame { get; }

        /// <summary>
        /// Sets the bitmap format for the callback.
        /// </summary>
        /// <param name="format">Bitmap format of the video frame</param>
        void SetFormat(BitmapFormat format);
    }
}
