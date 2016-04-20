using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core
{
    public static class IntPtrExtensions
    {
        public static string ToStringAnsi(IntPtr ptr)
        {
            return ptr != IntPtr.Zero ? Marshal.PtrToStringAnsi(ptr) : null;
        }
    }
}