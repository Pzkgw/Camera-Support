
using Declarations;
using LibVlcWrapper;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Implementation.Loggers
{
    internal unsafe sealed class LogSubscriber : DisposableBase
    {
        private IntPtr m_instance;
        private LogCallback m_callback;
        private ILogger m_logger;
        private const int BUFFER_SIZE = 10240;

        public LogSubscriber(ILogger logger, IntPtr pInstance)
        {
            m_instance = pInstance;
            m_logger = logger;
            m_callback = OnLogCallback;
            IntPtr hCallback = Marshal.GetFunctionPointerForDelegate(m_callback);
            LibVlcMethods.libvlc_log_set(m_instance, hCallback, IntPtr.Zero);
        }

        private void OnLogCallback(void* data, libvlc_log_level level, void* ctx, char* fmt, char* args)
        {
            try
            {
                char* buffer = stackalloc char[BUFFER_SIZE];
                int len = vsprintf(buffer, fmt, args);
                string msg = Marshal.PtrToStringAnsi(new IntPtr(buffer), len);

                switch (level)
                {
                    case libvlc_log_level.LIBVLC_DEBUG:
                        m_logger.Debug(msg);
                        break;
                    case libvlc_log_level.LIBVLC_NOTICE:
                        m_logger.Info(msg);
                        break;
                    case libvlc_log_level.LIBVLC_WARNING:
                        m_logger.Warning(msg);
                        break;
                    case libvlc_log_level.LIBVLC_ERROR:
                    default:
                        m_logger.Error(msg);
                        break;
                }
            }
            catch (Exception ex)
            {
                m_logger.Error("Failed to handle log callback, reason : " + ex.Message);
                throw ex;
            }
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                LibVlcMethods.libvlc_log_unset(m_instance);
            }
            catch (Exception ex)
            {
                throw ex;
            }
                      
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
