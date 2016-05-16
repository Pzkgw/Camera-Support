
using System;
using Declarations.Media;
using Declarations.Events;

namespace Declarations.Discovery
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMediaDiscoverer : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        /// 
        /// </summary>
        string LocalizedName { get; }

        /// <summary>
        /// 
        /// </summary>
        IMediaList MediaList { get; }

        /// <summary>
        /// 
        /// </summary>
        IMediaDiscoveryEvents Events { get; }
    }
}
