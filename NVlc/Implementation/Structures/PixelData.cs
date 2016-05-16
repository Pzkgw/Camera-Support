
using System;
using Implementation.Utils;

namespace Implementation
{
    internal unsafe struct PixelData : IDisposable
    {
        public byte* pPixelData;
        public int size;

        public PixelData(int size)
        {
            this.size = size;
            this.pPixelData = (byte*)MemoryHeap.Alloc(size);
        }

        #region IDisposable Members

        public void Dispose()
        {
            MemoryHeap.Free(this.pPixelData);
        }

        #endregion

        public static bool operator ==(PixelData pd1, PixelData pd2)
        {
            return (pd1.size == pd2.size && pd1.pPixelData == pd2.pPixelData);
        }

        public static bool operator !=(PixelData pd1, PixelData pd2)
        {
            return !(pd1 == pd2);
        }

        public override int GetHashCode()
        {
            return size.GetHashCode() ^ pPixelData->GetHashCode();
        }

        public override bool Equals(object obj)
        {
            PixelData pd = (PixelData)obj;
            if (pd == null)
            {
                return false;
            }

            return this == pd;
        }
    }
}
