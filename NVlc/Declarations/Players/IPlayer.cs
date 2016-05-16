
using System;
using System.Collections.Generic;
using Declarations.Media;
using Declarations.Events;

namespace Declarations.Players
{
    /// <summary>
    /// Represents basic media player functionality.
    /// </summary>
    public interface IPlayer : IDisposable, IEqualityComparer<IPlayer>
    {
        /// <summary>
        /// Opens new media item.
        /// </summary>
        /// <param name="media">Media item to play</param>
        void Open(IMedia media);

        /// <summary>
        /// Plays media item.
        /// </summary>
        void Play();

        /// <summary>
        /// Pauses playback of the media.
        /// </summary>
        void Pause();

        /// <summary>
        /// Stops the playback.
        /// </summary>
        void Stop();

        /// <summary>
        /// Gets or sets the media time in milliseconds.
        /// </summary>
        long Time { get; set; }

        /// <summary>
        /// Gets or sets media position.
        /// </summary>
        float Position { get; set; }

        /// <summary>
        /// Gets the media length in milliseconds.
        /// </summary>
        long Length { get; }

        /// <summary>
        /// Gets player events.
        /// </summary>
        IEventBroker Events { get; }

        /// <summary>
        /// Gets value indicating whether the player is playing
        /// </summary>
        bool IsPlaying { get; }

        /// <summary>
        /// Gets reference to current media instance
        /// </summary>
        IMedia CurrentMedia { get; }
    }
}
