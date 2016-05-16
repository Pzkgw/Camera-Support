
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Declarations.Events
{
   /// <summary>
   /// Events raised by IMediaListPlayer object
   /// </summary>
   public interface IMediaListPlayerEvents
   {
      event EventHandler MediaListPlayerPlayed;

      event EventHandler<MediaListPlayerNextItemSet> MediaListPlayerNextItemSet;

      event EventHandler MediaListPlayerStopped;
   }
}
