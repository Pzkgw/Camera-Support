﻿
using System;
using Declarations.Enums;

namespace Declarations
{
    /// <summary>
    /// Specifies the attributes of an elementary stream
    /// </summary>
    [Serializable]
    public class StreamInfo
    {
        public StreamInfo()
        {
            ID = 1;
            Group = 1;
        }
        /// <summary>
        /// Set the category of the elementary stream
        /// </summary>
        public StreamCategory Category { get; set; }

        /// <summary>
        /// Set the ID of the elementary stream
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Set the group of the elementary stream
        /// </summary>
        public int Group { get; set; }

        /// <summary>
        /// Size of stream in bytes
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Frame rate of a video elementary stream
        /// </summary>
        public int FPS { get; set; }

        /// <summary>
        /// Width of video or subtitle elementary streams
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Height of video or subtitle elementary streams
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Set the codec of the elementary stream
        /// </summary>
        public Enum Codec { get; set; }  
   
        /// <summary>
        /// Display aspect ratio of a video elementary stream
        /// </summary>
        public AspectRatioMode AspectRatio { get; set; }

        /// <summary>
        /// Sample rate of an audio elementary stream
        /// </summary>
        public int Samplerate { get; set; }

        /// <summary>
        /// Channels count of an audio elementary stream
        /// </summary>
        public int Channels { get; set; }
    }
}
