
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Declarations.Media;

namespace Declarations.Events
{
   public class MediaListItemAdded : EventArgs
   {
      public MediaListItemAdded(IMedia item, int index)
      {
         Item = item;
         Index = index;
      }

      public IMedia Item { get; private set; }
      public int Index { get; private set; }
   }

   public class MediaListWillAddItem : EventArgs
   {
      public MediaListWillAddItem(IMedia item, int index)
      {
         Item = item;
         Index = index;
      }

      public IMedia Item { get; private set; }
      public int Index { get; private set; }
   }

   public class MediaListItemDeleted : EventArgs
   {
      public MediaListItemDeleted(IMedia item, int index)
      {
         Item = item;
         Index = index;
      }

      public IMedia Item { get; private set; }
      public int Index { get; private set; }
   }

   public class MediaListWillDeleteItem : EventArgs
   {
      public MediaListWillDeleteItem(IMedia item, int index)
      {
         Item = item;
         Index = index;
      }

      public IMedia Item { get; private set; }
      public int Index { get; private set; }
   }

   public class MediaListPlayerNextItemSet : EventArgs
   {
      public MediaListPlayerNextItemSet(IMedia item)
      {
         Item = item;
      }
      public IMedia Item;
   }
}
