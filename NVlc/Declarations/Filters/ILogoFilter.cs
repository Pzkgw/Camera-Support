namespace Declarations.Filters
{
    /// <summary>
    /// Logo overlay filter.
    /// </summary>
    public interface ILogoFilter
   {
      /// <summary>
      /// Enables or disables logo filter
      /// </summary>
      bool Enabled { get; set; }

      /// <summary>
      /// Full path of the image files to use.
      /// </summary>
      string File { get; set; }

      /// <summary>
      /// X coordinate of the logo.
      /// </summary>
      int X { get; set; }

      /// <summary>
      /// Y coordinate of the logo.
      /// </summary>
      int Y { get; set; }

      /// <summary>
      /// Individual image display time of 0 - 60000 ms.
      /// </summary>
      int Delay { get; set; }

      /// <summary>
      /// Number of loops for the logo animation. -1 = continuous, 0 = disabled.
      /// </summary>
      int Repeat { get; set; }

      /// <summary>
      /// Logo opacity value (from 0 for full transparency to 255 for full opacity).
      /// </summary>
      int Opacity { get; set; }

      /// <summary>
      /// Logo position.
      /// </summary>
      Position Position { get; set; }
   }
}
