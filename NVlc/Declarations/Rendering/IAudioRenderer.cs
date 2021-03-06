﻿
using System;

namespace Declarations
{
    /// <summary>
    /// Enables custom processing of audio samples
    /// </summary>
    public interface IAudioRenderer : IRenderer
    {
        /// <summary>
        /// Sets callback methods for volume change and audio samples playback
        /// </summary>
        /// <param name="volume">Callback method invoked when volume changed or muted</param>
        /// <param name="sound">Callback method invoked when new audio samples should be played</param>
        void SetCallbacks(VolumeChangedEventHandler volume, NewSoundEventHandler sound);

        /// <summary>
        /// Sets callback for audio playback
        /// </summary>
        /// <param name="callbacks"></param>
        void SetCallbacks(AudioCallbacks callbacks);

        /// <summary>
        /// Sets audio format
        /// </summary>
        /// <param name="format"></param>
        /// <remarks>Mutually exclusive with SetFormatCallback</remarks>
        void SetFormat(SoundFormat format);

        /// <summary>
        /// Sets audio format callback, to get/set format before playback starts
        /// </summary>
        /// <param name="formatSetup"></param>
        /// <remarks>Mutually exclusive with SetFormat</remarks>
        void SetFormatCallback(Func<SoundFormat, SoundFormat> formatSetup);
    }
}
