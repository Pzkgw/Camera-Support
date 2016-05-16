using System.ComponentModel;

namespace Declarations
{
    /// <summary>
    /// Available video aspect ratio modes
    /// </summary>
    public enum AspectRatioMode
   {
      /// <summary>
      /// Default aspect ratio of the frame
      /// </summary>
      [Description("Default")]
      Default = 0,

      /// <summary>
      /// 1:1
      /// </summary>
      [Description("1:1")]
      Mode1,

      /// <summary>
      /// 4:3
      /// </summary>
      [Description("4:3")]
      Mode2,

      /// <summary>
      /// 16:9
      /// </summary>
      [Description("16:9")]
      Mode3,

      /// <summary>
      /// 16:10
      /// </summary>
      [Description("16:10")]
      Mode4,

      /// <summary>
      /// 2.21:1
      /// </summary>
      [Description("2.21:1")]
      Mode5,

      /// <summary>
      /// 2.35:1
      /// </summary>
      [Description("2.35:1")]
      Mode6,

      /// <summary>
      /// 2:39:1
      /// </summary>
      [Description("2:39:1")]
      Mode7,

      /// <summary>
      /// 5:4
      /// </summary>
      [Description("5:4")]
      Mode8,
   }
}