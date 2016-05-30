
using Declarations;
using LibVlcWrapper;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Implementation.Loggers
{
    internal unsafe struct UnBuffer
    {
        public unsafe fixed char _buff[4096];
    }

    internal unsafe sealed class LogSubscriber : DisposableBase
    {
        private IntPtr m_instance;
        private LogCallback m_callback;
        private ILogger m_logger;

        private UnBuffer _buff;
        private string _msg;

        public LogSubscriber(ILogger logger, IntPtr pInstance)
        {
            _buff = default(UnBuffer);

            m_instance = pInstance;
            m_logger = logger;
            m_callback = OnLogCallback;
            LibVlcMethods.libvlc_log_set(m_instance, Marshal.GetFunctionPointerForDelegate(m_callback), IntPtr.Zero);
        }

        private void OnLogCallback(void* data, libvlc_log_level level, void* ctx, char* fmt, char* args)
        {

            fixed (char* buff = _buff._buff)
            {
                _msg = Marshal.PtrToStringAnsi(new IntPtr(buff), vsprintf(buff, fmt, args));
            }

            switch (level)
            {
                case libvlc_log_level.LIBVLC_DEBUG:
                    //m_logger.Debug(_msg);
                    break;
                case libvlc_log_level.LIBVLC_NOTICE:
                    m_logger.Info(_msg);
                    break;
                case libvlc_log_level.LIBVLC_WARNING:
                    m_logger.Warning(_msg);
                    break;
                case libvlc_log_level.LIBVLC_ERROR:
                default:
                    m_logger.Error(_msg);
                    break;
            }
            _msg = null;
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                LibVlcMethods.libvlc_log_unset(m_instance);
                //Marshal.FreeHGlobal(_buff);
            }
            catch { }

            if (disposing)
            {
                m_callback = null;
            }
        }

        [DllImport("msvcrt", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private static extern int vsprintf(char* str, char* format, char* arg);
    }
}
