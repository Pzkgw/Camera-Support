
using System;
using System.Drawing;
using Declarations.Filters;
using LibVlcWrapper;
using System.Runtime.InteropServices;

namespace Implementation.Filters
{
   internal class CropFilter : ICropFilter
   {
      IntPtr m_hMediaPlayer;
      bool m_enabled = false;
      
      public CropFilter(IntPtr hMediaPlayer)
      {
         m_hMediaPlayer = hMediaPlayer;
      }

      #region ICropFilter Members

      public bool Enabled
      {
         get
         {
            return m_enabled;
         }
         set
         {
            m_enabled = value;
            if (m_enabled)
            {
               CropGeometry = CropArea.ToCropFilterString();
            }
            else
            {
               CropGeometry = null;
            }
         }
      }

      public Rectangle CropArea { get; set; }

      #endregion

      string CropGeometry
      {
         get
         {
            IntPtr pData = LibVlcMethods.libvlc_video_get_crop_geometry(m_hMediaPlayer);
            return Marshal.PtrToStringAnsi(pData);
         }
         set
         {
            LibVlcMethods.libvlc_video_set_crop_geometry(m_hMediaPlayer, value.ToUtf8());
         }
      }
   }
}
