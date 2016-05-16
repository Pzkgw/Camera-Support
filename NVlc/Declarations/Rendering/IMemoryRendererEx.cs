
using System;

namespace Declarations
{
    /// <summary>
    /// Contains methods for setting custom processing of video frames.
    /// </summary>
    public interface IMemoryRendererEx : IRenderer
    {
        /// <summary>
        /// Sets the callback which invoked when new frame should be displayed
        /// </summary>
        /// <param name="callback">Callback method</param>
        void SetCallback(NewFrameDataEventHandler callback);

        /// <summary>
        /// Gets the latest video frame that was displayed.
        /// </summary>
        PlanarFrame CurrentFrame { get; }

        /// <summary>
        /// Sets the callback invoked before the media playback starts to set the desired frame format.
        /// </summary>
        /// <param name="setupCallback"></param>
        /// <remarks>If not set, original media format will be used</remarks>
        void SetFormatSetupCallback(Func<BitmapFormat, BitmapFormat> setupCallback);

        /// <summary>
        /// Storage aspect ratio
        /// </summary>
        AspectRatio SAR { set; get; }
    }
}
