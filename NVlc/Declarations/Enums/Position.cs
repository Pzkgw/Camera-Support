
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Declarations
{
   /// <summary>
   /// Position on the video screen
   /// </summary>
   public enum Position
   {
      Center = 0,
      Left = 1,
      Right = 2,
      Top = 4,
      Bottom = 8,
      TopRight = Top | Right,
      TopLeft = Top | Left,
      BottomRight = Bottom | Right,
      BottomLeft = Bottom | Left
   }
}
