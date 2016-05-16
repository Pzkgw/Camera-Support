
using System;
using System.Collections.Generic;
using Declarations.Events;

namespace Declarations.Media
{
    /// <summary>
    /// Represents a collection of media objects.
    /// </summary>
    public interface IMediaList : IList<IMedia>, IDisposable
   {
      /// <summary>
      /// Gets events fired by media list instance.
      /// </summary>
      IMediaListEvents Events { get; }
   }
}
