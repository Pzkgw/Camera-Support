
using System;

namespace Declarations.Media
{
    /// <summary>
    /// Represents audio/visual media file.
    /// </summary>
    public interface IMediaFromFile : IMedia
    {
        /// <summary>
        /// Gets meta data of the media.
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        string GetMetaData(MetaDataType dataType);

        /// <summary>
        /// Sets meta data of the media.
        /// </summary>
        /// <param name="dataType">Meta data type</param>
        /// <param name="argument">New meta data value</param>
        void SetMetaData(MetaDataType dataType, string argument);

        /// <summary>
        /// Saves changes to media meta data.
        /// </summary>
        void SaveMetaData();

        /// <summary>
        /// Gets the duration of media in milliseconds.
        /// </summary>
        long Duration { get; }

        /// <summary>
        /// Gets information describing media elementary streams.
        /// </summary>
        /// <remarks>Returns array of media tracks info in case of success, or null in case of failure</remarks>
        [Obsolete("Use TrackInfoEx")]
        MediaTrackInfo[] TracksInfo { get; }
    }
}
