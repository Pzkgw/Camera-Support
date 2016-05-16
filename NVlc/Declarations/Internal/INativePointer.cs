
using System;


namespace Declarations
{
   /// <summary>
   /// Represents a managed object with encapsulated native pointer.
   /// </summary>
   public interface INativePointer
   {
      /// <summary>
      /// Reference to a native memory block.
      /// </summary>
      IntPtr Pointer { get; }
   }
}
