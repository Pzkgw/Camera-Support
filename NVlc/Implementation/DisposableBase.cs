
using System;
using System.Runtime.ConstrainedExecution;

namespace Implementation
{
    /// <summary>
    /// Base class for managing native resources.
    /// </summary>
    public abstract class DisposableBase : CriticalFinalizerObject, IDisposable
    {
        private volatile bool m_isDisposed;

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            if (!m_isDisposed)
            {
                Dispose(true);
                GC.SuppressFinalize(this);
                m_isDisposed = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected abstract void Dispose(bool disposing);
        //      if (disposing)
        //      {
        //         // get rid of managed resources 
        //      }
        //      // get rid of unmanaged resources 

        /// <summary>
        /// 
        /// </summary>
        ~DisposableBase()
        {
            if (!m_isDisposed)
            {
                Dispose(false);
                m_isDisposed = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected void VerifyObjectNotDisposed()
        {
            if (m_isDisposed)
            {
                throw new ObjectDisposedException(this.GetType().Name);
            }
        }
    }
}
