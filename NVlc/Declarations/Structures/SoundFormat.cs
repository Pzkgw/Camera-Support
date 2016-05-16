
using System;
using Declarations.Enums;

namespace Declarations
{
    /// <summary>
    /// Specifies the parameters of the sound.
    /// </summary>
    [Serializable]
    public class SoundFormat
    {
        /// <summary>
        /// Initializes new instance of SoundFormat class
        /// </summary>
        /// <param name="soundType"></param>
        /// <param name="rate"></param>
        /// <param name="channels"></param>
        public SoundFormat(SoundType soundType, int rate, int channels)
        {
            SoundType = soundType;
            Format = soundType.ToString();
            Rate = rate;
            Channels = channels;
            Init();
            BlockSize = BitsPerSample / 8 * Channels;
            UseCustomAudioRendering = true;
        }

        private void Init()
        {
            switch (SoundType)
            {
                case SoundType.S16N:
                    BitsPerSample = 16;
                    break;
            }
        }

        /// <summary>
        /// Audio format
        /// </summary>
        public string Format { get; private set; }

        /// <summary>
        /// Sampling rate in Hz
        /// </summary>
        public int Rate { get; private set; }

        /// <summary>
        /// Number of channels used by audio sample
        /// </summary>
        public int Channels { get; private set; }

        /// <summary>
        /// Size of single audio sample in bytes
        /// </summary>
        public int BitsPerSample { get; private set; }

        /// <summary>
        /// Specifies sound sample format
        /// </summary>
        public SoundType SoundType { get; private set; }

        /// <summary>
        /// Size of audio block (BitsPerSample / 8 * Channels)
        /// </summary>
        public int BlockSize { get; private set; }

        /// <summary>
        /// Indicated whether to use custom audio renderer (True), or to use default audio output (False)
        /// </summary>
        public bool UseCustomAudioRendering { get; set; }
    }
}
