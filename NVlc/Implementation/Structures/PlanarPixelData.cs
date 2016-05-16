
using System;
using Implementation.Utils;

namespace Implementation
{
    internal unsafe struct PlanarPixelData : IDisposable
    {
        public int[] Sizes;
        public byte** Data;

        public PlanarPixelData(int[] lineSizes)
        {
            Sizes = lineSizes;

            Data = (byte**)MemoryHeap.Alloc(sizeof(byte*) * Sizes.Length);

            for (int i = 0; i < Sizes.Length; i++)
            {
                Data[i] = (byte*)MemoryHeap.Alloc(sizeof(byte) * Sizes[i]);
            }
        }

        public void Dispose()
        {
            for (int i = 0; i < Sizes.Length; i++)
            {
                MemoryHeap.Free(Data[i]);
            }

            MemoryHeap.Free(Data);
        }

        public static bool operator ==(PlanarPixelData pd1, PlanarPixelData pd2)
        {
            return (pd1.Data == pd2.Data && pd1.Sizes == pd2.Sizes);
        }

        public static bool operator !=(PlanarPixelData pd1, PlanarPixelData pd2)
        {
            return !(pd1 == pd2);
        }

        public override int GetHashCode()
        {
            return Sizes.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            PlanarPixelData pd = (PlanarPixelData)obj;
            if (pd == null)
            {
                return false;
            }

            return this == pd;
        }
    }
}
