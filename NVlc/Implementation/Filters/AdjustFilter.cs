
using System;
using Declarations.Filters;
using LibVlcWrapper;

namespace Implementation.Filters
{
   internal class AdjustFilter : IAdjustFilter
   {
      IntPtr m_hMediaPlayer;

      public AdjustFilter(IntPtr hMediaPlayer)
      {
         m_hMediaPlayer = hMediaPlayer;
      }

      #region IAdjustFilter Members

      public bool Enabled
      {
         get
         {
            return GetVideoAdjustType<int>(libvlc_video_adjust_option_t.libvlc_adjust_Enable) == 1;
         }
         set
         {
            SetVideoAdjustType<int>(libvlc_video_adjust_option_t.libvlc_adjust_Enable, Convert.ToInt32(value));
         }
      }

      public float Contrast
      {
         get
         {
            return GetVideoAdjustType<float>(libvlc_video_adjust_option_t.libvlc_adjust_Contrast);
         }
         set
         {
            SetVideoAdjustType<float>(libvlc_video_adjust_option_t.libvlc_adjust_Contrast, value);
         }
      }

      public float Brightness
      {
         get
         {
            return GetVideoAdjustType<float>(libvlc_video_adjust_option_t.libvlc_adjust_Brightness);
         }
         set
         {
            SetVideoAdjustType<float>(libvlc_video_adjust_option_t.libvlc_adjust_Brightness, value);
         }
      }

      public int Hue
      {
         get
         {
            return GetVideoAdjustType<int>(libvlc_video_adjust_option_t.libvlc_adjust_Enable);
         }
         set
         {
            SetVideoAdjustType<int>(libvlc_video_adjust_option_t.libvlc_adjust_Enable, value);
         }
      }

      public float Saturation
      {
         get
         {
            return GetVideoAdjustType<float>(libvlc_video_adjust_option_t.libvlc_adjust_Saturation);
         }
         set
         {
            SetVideoAdjustType<float>(libvlc_video_adjust_option_t.libvlc_adjust_Saturation, value);
         }
      }

      public float Gamma
      {
         get
         {
            return GetVideoAdjustType<float>(libvlc_video_adjust_option_t.libvlc_adjust_Gamma);
         }
         set
         {
            SetVideoAdjustType<float>(libvlc_video_adjust_option_t.libvlc_adjust_Gamma, value);
         }
      }

      #endregion

      private void SetVideoAdjustType<T>(libvlc_video_adjust_option_t adjustType, T value)
      {
         if (typeof(int) == typeof(T))
         {
            LibVlcMethods.libvlc_video_set_adjust_int(m_hMediaPlayer, adjustType, (int)(object)value);
         }
         else
         {
            LibVlcMethods.libvlc_video_set_adjust_float(m_hMediaPlayer, adjustType, (float)(object)value);
         }
      }

      private T GetVideoAdjustType<T>(libvlc_video_adjust_option_t adjustType)
      {
         if (typeof(int) == typeof(T))
         {
            return (T)(object)LibVlcMethods.libvlc_video_get_adjust_int(m_hMediaPlayer, adjustType);
         }
         else
         {
            return (T)(object)LibVlcMethods.libvlc_video_get_adjust_float(m_hMediaPlayer, adjustType);
         }
      }
   }

}
