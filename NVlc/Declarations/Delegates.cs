﻿
using System;
using System.Drawing;

namespace Declarations
{
    /// <summary>
    /// Represents a callback method that will handle each frame in video sequence as System.Drawing.Bitmap object.
    /// </summary>
    /// <param name="frame">New frame to display</param>
    public delegate void NewFrameEventHandler(Bitmap frame);

    /// <summary>
    /// Represents the method that will handle each frame in video sequence as array of raw pixel planes.
    /// </summary>
    /// <param name="frame"></param>
    public delegate void NewFrameDataEventHandler(PlanarFrame frame);

    /// <summary>
    /// Represents a callback method which handles audio samples
    /// </summary>
    /// <param name="newSound"></param>
    public delegate void NewSoundEventHandler(Sound newSound);

    /// <summary>
    /// Represents a callback method which handles change in volume or mute values
    /// </summary>
    /// <param name="volume"></param>
    /// <param name="mute"></param>
    public delegate void VolumeChangedEventHandler(float volume, bool mute);

    /// <summary>
    /// Container for custom audio processing callbacks
    /// </summary>
    public class AudioCallbacks
    {
        /// <summary>
        /// Callback method for handling voulume and mute proerties change
        /// </summary>
        public VolumeChangedEventHandler VolumeCallback;

        /// <summary>
        /// Callback method for handling PCM samples
        /// </summary>
        public NewSoundEventHandler SoundCallback;

        /// <summary>
        /// Callback method called when media player switches to Pause state
        /// </summary>
        public Action<long> PauseCallback;

        /// <summary>
        /// Callback method called when media player switches to Playback state
        /// </summary>
        public Action<long> ResumeCallback;

        /// <summary>
        /// Callback method called when all pending buffers should be discarded
        /// </summary>
        public Action<long> FlushCallback;

        /// <summary>
        /// Callback method called when all pending buffers must be played
        /// </summary>
        public Action DrainCallback;
    }
}
