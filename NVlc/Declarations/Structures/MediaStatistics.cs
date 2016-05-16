
using System;

namespace Declarations
{
    /// <summary>
    /// Data structure containing media statistics' parameters.
    /// </summary>
    [Serializable]
   public struct MediaStatistics
   {
      /* Input */
      public int ReadBytes;
      public float InputBitrate;

      /* Demux */
      public int DemuxReadBytes;
      public float DemuxBitrate;
      public int DemuxCorrupted;
      public int DemuxDiscontinuity;

      /* Decoders */
      public int DecodedVideo;
      public int DecodedAudio;

      /* Video Output */
      public int DisplayedPictures;
      public int LostPictures;

      /* Audio output */
      public int PlayedAbuffers;
      public int LostAbuffers;

      /* Stream output */
      public int SentPackets;
      public int SentBytes;
      public float SendBitrate;
   }
}
