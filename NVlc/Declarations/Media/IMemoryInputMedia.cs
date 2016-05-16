
using System;
using System.Drawing;

namespace Declarations.Media
{
    /// <summary>
    /// Enables elementary stream (audio, video, subtitles or data) frames insertion into VLC engine (based on imem access module)
    /// </summary>
    public interface IMemoryInputMedia : IMedia
    {
        /// <summary>
        /// Initializes instance of the media object with stream information and frames' queue size
        /// </summary>
        /// <param name="streamInfo"></param>
        /// <param name="maxFramesInQueue">Maximum items in the queue. If the queue is full any AddFrame overload 
        /// will block until queue slot becomes available</param>
        void Initialize(StreamInfo streamInfo, int maxItemsInQueue = 30);

        /// <summary>
        /// Add frame of elementary stream data from memory on native heap
        /// </summary>
        /// <param name="streamInfo"></param>
        /// <remarks>This function copies frame data to internal buffer, so native memory may be safely freed</remarks>
        void AddFrame(FrameData frame);

        /// <summary>
        /// Add frame of elementary stream data from memory on managed heap
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pts">Presentation time stamp</param>
        /// <param name="dts">Decoding time stamp. -1 for unknown</param>
        /// <remarks>Time origin for both pts and dts is 0</remarks>
        void AddFrame(byte[] data, long pts, long dts = -1);

        /// <summary>
        /// Add frame of video stream from System.Drawing.Bitmap object
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="pts">Presentation time stamp</param>
        /// <param name="dts">Decoding time stamp. -1 for unknown</param>
        /// <remarks>Time origin for both pts and dts is 0</remarks>
        /// <remarks>This function copies bitmap data to internal buffer, so bitmap may be safely disposed</remarks>
        void AddFrame(Bitmap bitmap, long pts, long dts = -1);

        /// <summary>
        /// Sets handler for exceptions thrown by background threads
        /// </summary>
        /// <param name="handler"></param>
        void SetExceptionHandler(Action<Exception> handler);

        /// <summary>
        /// Gets number of pending frames in queue 
        /// </summary>
        int PendingFramesCount { get; }
    }
}
