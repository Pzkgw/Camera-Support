
using System;

namespace Declarations
{
    /// <summary>
    /// Data structure containing parameters of elementary media stream
    /// </summary>
    [Serializable]
    public class MediaTrackInfo
    {
        public UInt32 Codec;
        public int Id;
        public TrackType TrackType;
        public int Profile;
        public int Level;
        public int Channels;
        public int Rate;
        public int Height;
        public int Width;
    }

    [Serializable]
    public class MediaTrack
    {
        public MediaTrack()
        {
            TrackType = TrackType.Unknown;
        }

        public string Codec;
        public string OriginalFourCC;
        public int Id;
        public TrackType TrackType;
        public uint Bitrate;
        public string Language;
        public string Description;
    }

    [Serializable]
    public class AudioTrack : MediaTrack
    {
        public AudioTrack()
        {
            TrackType = TrackType.Audio;
        }

        public uint Channels;
        public uint Rate;
    }

    [Serializable]
    public class VideoTrack : MediaTrack
    {
        public VideoTrack()
        {
            TrackType = TrackType.Video;
        }

        public uint Height;
        public uint Width;
        public uint Sar_num;
        public uint Sar_den;
        public uint Frame_rate_num;
        public uint Frame_rate_den;
    }

    [Serializable]
    public class SubtitlesTrack : MediaTrack
    {
        public SubtitlesTrack()
        {
            TrackType = TrackType.Text;
        }

        public string Encoding;
    }
}
