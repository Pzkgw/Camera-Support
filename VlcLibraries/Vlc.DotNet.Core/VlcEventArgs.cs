using System;

namespace Vlc.DotNet.Core
{
    /// <summary>
    /// Vlc event args
    /// </summary>
    /// <typeparam name="T">Type of return data</typeparam>
    public class VlcEventArgs<T> : EventArgs
    {
        public VlcEventArgs(T data)
        {
            Data = data;
        }

        public T Data { get; private set; }
    }
}