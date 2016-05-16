
using System;

namespace Declarations
{
    /// <summary>
    /// Base type for custom rendering types
    /// </summary>
    public interface IRenderer : IDisposable
    {
        /// <summary>
        /// Sets exception handler for exceptions thrown by background threads.
        /// </summary>
        /// <param name="handler"></param>
        void SetExceptionHandler(Action<Exception> handler);

        /// <summary>
        /// Gets the actual frame rate of the rendering.
        /// </summary>
        int ActualFrameRate { get; }
    }
}
