
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Declarations
{
   /// <summary>
   /// Possible state of the media objects
   /// </summary>
   public enum MediaState
   {
      NothingSpecial = 0,
      Opening,
      Buffering,
      Playing,
      Paused,
      Stopped,
      Ended,
      Error
   }
}
