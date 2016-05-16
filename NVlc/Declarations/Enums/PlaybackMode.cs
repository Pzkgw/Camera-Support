
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Declarations
{
   /// <summary>
   /// Available playback modes for the media list player.
   /// </summary>
   public enum PlaybackMode
   {
      /// <summary>
      /// Playes items sequentially.
      /// </summary>
      Default,

      /// <summary>
      /// Loops playlist on end.
      /// </summary>
      Loop,

      /// <summary>
      /// Repeats the current item until another item is forced.
      /// </summary>
      Repeat
   }
}
