
using System;
using System.Collections.Generic;
using Declarations.Events;
using Declarations.Structures;

namespace Declarations.Media
{
    /// <summary>
    /// Represents a media object (file, network stream, capture device, etc.)
    /// </summary>
    public interface IMedia : IDisposable, IEqualityComparer<IMedia>
    {
        /// <summary>
        /// Sets or gets the media path.
        /// </summary>
        string Input { get; set; }

        /// <summary>
        /// Add options to media.
        /// </summary>
        /// <param name="options">Collection of options</param>
        void AddOptions(IEnumerable<string> options);

        /// <summary>
        /// Gets media state.
        /// </summary>
        MediaState State { get; }

        /// <summary>
        /// Adds option with a configuration flag.
        /// </summary>
        /// <param name="option">Option</param>
        /// <param name="flag">Configuration flag</param>
        void AddOptionFlag(string option, int flag);

        /// <summary>
        /// Duplicates the media instance
        /// </summary>
        /// <returns></returns>
        IMedia Duplicate();

        /// <summary>
        /// Parses media synchronously or asynchronously.
        /// </summary>
        /// <param name="aSync">True for sync ,false for async</param>
        void Parse(bool aSync);

        /// <summary>
        /// Gets value indication whether the media is parsed.
        /// </summary>
        bool IsParsed { get; }

        /// <summary>
        /// Gets or sets user defined data for the media.
        /// </summary>
        IntPtr Tag { get; set; }

        /// <summary>
        /// Gets events fired by media instance.
        /// </summary>
        IMediaEvents Events { get; }

        /// <summary>
        /// Gets statistic data associated with current media.
        /// </summary>
        MediaStatistics Statistics { get; }

        /// <summary>
        /// Gets media's sub item nodes.
        /// </summary>
        IMediaList SubItems { get; }

        /// <summary>
        /// Gets information describing media elementary streams.
        /// </summary>
        /// <remarks>Returns array of media tracks info in case of success</remarks>
        MediaTrack[] TracksInfoEx { get; }

        /// <summary>
        /// Gets or sets additional media which will play synchronously.
        /// </summary>
        SlaveMedia SlaveMedia { set; get; }
    }
}
