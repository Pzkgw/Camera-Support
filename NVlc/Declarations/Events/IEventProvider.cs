
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Declarations.Events
{
   public interface IEventProvider
   {
      IntPtr EventManagerHandle { get; }
   }
}
