
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Declarations.Filters
{
   /// <summary>
   /// Represents video crop filter
   /// </summary>
   public interface ICropFilter
   {
      /// <summary>
      /// Enables or disables croping filter
      /// </summary>
      bool Enabled { get; set; }

      /// <summary>
      /// Gets or sets croping area.
      /// </summary>
      Rectangle CropArea { get; set; }
   }
}
