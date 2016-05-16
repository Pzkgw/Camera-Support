
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Declarations.Filters
{
   /// <summary>
   /// Manages deinterlacing functionality.
   /// </summary>
   public interface IDeinterlaceFilter
   {
      /// <summary>
      /// Enables or disables deinterlacing
      /// </summary>
      bool Enabled { get; set; }

      /// <summary>
      /// Gets or sets deinterlace algorithm
      /// </summary>
      DeinterlaceMode Mode { get; set; }
   }
}
