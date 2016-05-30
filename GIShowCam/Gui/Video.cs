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
                _memRender = _mPlayer.CustomRenderer;

                //_mPlayer.WindowHandle = _form.panelVlc.Handle;  

                _memRender.SetCallback(delegate (Bitmap frame)
                {
                    _panGraphics.DrawImageUnscaled(frame, Point.Empty);
                });

                _memRender.SetFormat(_info.ImgFormat);
            }
            else
            {
                //_mPlayer.WindowHandle = IntPtr.Zero;

            }
        }

    }
}
