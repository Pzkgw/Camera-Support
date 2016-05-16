
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Implementation.Utils
{
    [SuppressUnmanagedCodeSecurity]
    internal unsafe class MemoryHeap
    {
        static int ph = GetProcessHeap();

        private MemoryHeap() { }

        /// <summary>
        /// Allocates a memory block of the given size. The allocated memory is
        /// automatically initialized to zero.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static void* Alloc(int size)
        {
            void* result = HeapAlloc(ph, HEAP_ZERO_MEMORY, size);
            if (result == null)
            {
                throw new OutOfMemoryException();
            }

            return result;
        }

        /// <summary>
        /// Frees a memory block.
        /// </summary>
        /// <param name="block"></param>
        public static void Free(void* block)
        {
            if (!HeapFree(ph, 0, block))
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Re-allocates a memory block. If the reallocation request is for a
        /// larger size, the additional region of memory is automatically
        /// initialized to zero.
        /// </summary>
        /// <param name="block"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static void* ReAlloc(void* block, int size)
        {
            void* result = HeapReAlloc(ph, HEAP_ZERO_MEMORY, block, size);
            if (result == null)
            {
                throw new OutOfMemoryException();
            }

            return result;
        }

        /// <summary>
        /// Returns the size of a memory block.
        /// </summary>
        /// <param name="block"></param>
        /// <returns></returns>
        public static int SizeOf(void* block)
        {
            int result = HeapSize(ph, 0, block);
            if (result == -1)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        // Heap API flags
        const int HEAP_ZERO_MEMORY = 0x00000008;

        // Heap API functions
        [DllImport("kernel32")]
        static extern int GetProcessHeap();

        [DllImport("kernel32")]
        static extern void* HeapAlloc(int hHeap, int flags, int size);

        [DllImport("kernel32")]
        static extern bool HeapFree(int hHeap, int flags, void* block);

        [DllImport("kernel32")]
        static extern void* HeapReAlloc(int hHeap, int flags, void* block, int size);

        [DllImport("kernel32")]
        static extern int HeapSize(int hHeap, int flags, void* block);

        [DllImport("Kernel32.dll", EntryPoint = "RtlMoveMemory", SetLastError = true)]
        public static unsafe extern void CopyMemory(void* dest, void* src, int size);
    }
}
