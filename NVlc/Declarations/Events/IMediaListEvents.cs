
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Declarations.Events
{
   /// <summary>
   /// Events raised by IMediaList object
   /// </summary>
   public interface IMediaListEvents
   {
      event EventHandler<MediaListItemAdded> ItemAdded;

      event EventHandler<MediaListWillAddItem> WillAddItem;

      event EventHandler<MediaListItemDeleted> ItemDeleted;

      event EventHandler<MediaListWillDeleteItem> WillDeleteItem;
   }
}
