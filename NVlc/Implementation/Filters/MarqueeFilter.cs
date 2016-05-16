
using System;
using Declarations;
using Declarations.Filters;
using LibVlcWrapper;
using System.Runtime.InteropServices;

namespace Implementation.Filters
{
   internal class MarqueeFilter : IMarqueeFilter
   {
      IntPtr m_hMediaPlayer;

      public MarqueeFilter(IntPtr hMediaPlayer)
      {
         m_hMediaPlayer = hMediaPlayer;
      }

      #region IMarqueeFilter Members

      public bool Enabled
      {
         get
         {
            return GetMarquee(libvlc_video_marquee_option_t.libvlc_marquee_Enable) == 1;
         }
         set
         {
            SetMarquee(libvlc_video_marquee_option_t.libvlc_marquee_Enable, Convert.ToInt32(value));
         }
      }

      public string Text
      {
         get
         {
            return GetMarqueeString(libvlc_video_marquee_option_t.libvlc_marquee_Text);
         }
         set
         {
            SetMarqueeString(libvlc_video_marquee_option_t.libvlc_marquee_Text,value);
         }
      }

      public VlcColor Color
      {
         get
         {
            return (VlcColor)GetMarquee(libvlc_video_marquee_option_t.libvlc_marquee_Color);
         }
         set
         {
            SetMarquee(libvlc_video_marquee_option_t.libvlc_marquee_Color, (int)value);
         }
      }

      public Position Position
      {
         get
         {
            return (Position)GetMarquee(libvlc_video_marquee_option_t.libvlc_marquee_Position);
         }
         set
         {
            SetMarquee(libvlc_video_marquee_option_t.libvlc_marquee_Position, (int)value);
         }
      }

      public int Refresh
      {
         get
         {
            return GetMarquee(libvlc_video_marquee_option_t.libvlc_marquee_Refresh);
         }
         set
         {
            SetMarquee(libvlc_video_marquee_option_t.libvlc_marquee_Refresh, value);
         }
      }

      public int Size
      {
         get
         {
            return GetMarquee(libvlc_video_marquee_option_t.libvlc_marquee_Size);
         }
         set
         {
            SetMarquee(libvlc_video_marquee_option_t.libvlc_marquee_Size, value);
         }
      }

      public int Timeout
      {
         get
         {
            return GetMarquee(libvlc_video_marquee_option_t.libvlc_marquee_Timeout);
         }
         set
         {
            SetMarquee(libvlc_video_marquee_option_t.libvlc_marquee_Timeout, value);
         }
      }

      public int X
      {
         get
         {
            return GetMarquee(libvlc_video_marquee_option_t.libvlc_marquee_X);
         }
         set
         {
            SetMarquee(libvlc_video_marquee_option_t.libvlc_marquee_X, value);
         }
      }

      public int Y
      {
         get
         {
            return GetMarquee(libvlc_video_marquee_option_t.libvlc_marquee_Y);
         }
         set
         {
            SetMarquee(libvlc_video_marquee_option_t.libvlc_marquee_Y, value);
         }
      }

      public int Opacity
      {
         get
         {
            return GetMarquee(libvlc_video_marquee_option_t.libvlc_marquee_Opacity);
         }
         set
         {
            SetMarquee(libvlc_video_marquee_option_t.libvlc_marquee_Opacity, value);
         }
      }

      #endregion

      int GetMarquee(libvlc_video_marquee_option_t option)
      {
         return LibVlcMethods.libvlc_video_get_marquee_int(m_hMediaPlayer, option);
      }

      void SetMarquee(libvlc_video_marquee_option_t option, int argument)
      {
         LibVlcMethods.libvlc_video_set_marquee_int(m_hMediaPlayer, option, argument);
      }

      string GetMarqueeString(libvlc_video_marquee_option_t option)
      {
         IntPtr pData = LibVlcMethods.libvlc_video_get_marquee_string(m_hMediaPlayer, option);
         return Marshal.PtrToStringAnsi(pData);
      }

      void SetMarqueeString(libvlc_video_marquee_option_t option, string argument)
      {
         LibVlcMethods.libvlc_video_set_marquee_string(m_hMediaPlayer, option, argument.ToUtf8());
      }    
   }
}
