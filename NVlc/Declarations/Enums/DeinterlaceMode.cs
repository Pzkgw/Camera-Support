
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Declarations
{
   /// <summary>
   /// Available deinterlace algorithms.
   /// </summary>
   public enum DeinterlaceMode
   {
      discard,
      blend,
      mean,
      bob,
      linear,
      x,
      yadif,
      yadif2x
   }
}
