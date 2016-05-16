
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Declarations.Filters
{
   /// <summary>
   /// Manages video adjustment parameters.
   /// </summary>
   public interface IAdjustFilter
   {
      /// <summary>
      /// Enables or disables video adjust filter.
      /// </summary>          
      bool Enabled { get; set; }

      /// <summary>
      /// Image contrast in the 0-2 range.
      /// </summary>          
      float Contrast { get; set; }

      /// <summary>
      /// Image brightness in the 0-2 range.
      /// </summary>       
      float Brightness { get; set; }

      /// <summary>
      /// Image hue in the 0-360 range
      /// </summary>    
      int Hue { get; set; }

      /// <summary>
      /// Image saturation in the 0-3 range.
      /// </summary>   
      float Saturation { get; set; }

      /// <summary>
      /// Image gamma in the 0-10 range.
      /// </summary>    
      float Gamma { get; set; }
   }
}
