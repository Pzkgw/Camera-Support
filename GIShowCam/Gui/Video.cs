using Declarations;
using System.Drawing;

namespace GIShowCam.Gui
{
    internal partial class GuiBase
    {
        Graphics _panGraphics;
        private void VideoInit()
        {
            _info.ImgFormat = new BitmapFormat(
                    _form.panelVlc.Width, _form.panelVlc.Height, ChromaType.RGBA);

            _panGraphics = _form.panelVlc.CreateGraphics();
        }

        private void ToggleDrawing(bool on)
        {
            if (on)
            {
                //_mPlayer.WindowHandle = _form.panelVlc.Handle;  

                _mPlayer.CustomRenderer.SetCallback(delegate (Bitmap frame)
                {
                    _panGraphics.DrawImageUnscaled(frame, Point.Empty);
                });

                _mPlayer.CustomRenderer.SetFormat(_info.ImgFormat);
            }
            else
            {
                //_mPlayer.WindowHandle = IntPtr.Zero;

            }
        }

    }
}
