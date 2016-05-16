
using System;

namespace Declarations
{
    /// <summary>
    /// Structure for pixel planes and their sizes
    /// </summary>
    public struct PlanarFrame
    {
        /// <summary>
        /// Initializes new instance
        /// </summary>
        /// <param name="planes"></param>
        /// <param name="lenghts"></param>
        public PlanarFrame(IntPtr[] planes, int[] lenghts)
            :this()
        {
            if (planes.Length != lenghts.Length)
            {
                throw new ArgumentException("Number of planes must be equal to lenghts array");
            }

            this.Planes = planes;
            this.Lenghts = lenghts;
        }

        /// <summary>
        /// Gets pointer array to the pixel planes on the native heap 
        /// </summary>
        public IntPtr[] Planes { get; set; }

        /// <summary>
        /// Gets length of each pixel plane
        /// </summary>
        public int[] Lenghts { get; set; }
    }
}
