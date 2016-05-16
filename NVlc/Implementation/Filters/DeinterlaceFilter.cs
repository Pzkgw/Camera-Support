
using System;
using Declarations;
using Declarations.Filters;
using LibVlcWrapper;

namespace Implementation.Filters
{
   internal class DeinterlaceFilter : IDeinterlaceFilter
   {
      IntPtr m_hMediaPlayer;
      bool m_enabled = false;
      private DeinterlaceMode m_mode;

      public DeinterlaceFilter(IntPtr hMediaPlayer)
      {
         m_hMediaPlayer = hMediaPlayer;
      }

      #region IDeinterlaceFilter Members

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
                  LibVlcMethods.libvlc_video_set_deinterlace(m_hMediaPlayer, Mode.ToString().ToUtf8());
              }
              else
              {
                  LibVlcMethods.libvlc_video_set_deinterlace(m_hMediaPlayer, null);
              }
          }
      }

      public DeinterlaceMode Mode 
      {
          get
          {
              return m_mode;
          }
          set
          {
              m_mode = value;
              LibVlcMethods.libvlc_video_set_deinterlace(m_hMediaPlayer, m_mode.ToString().ToUtf8());
          }
      }

      #endregion
   }
}
