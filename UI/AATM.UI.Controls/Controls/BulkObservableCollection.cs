using System.Collections.ObjectModel;
using System.Collections.Generic;
using System;

namespace AATM.UI.Controls
{
internal class BulkObservableCollection<T> : ObservableCollection<T>
    {
 /// <summary>
 /// Adds a range of items to the collection and raises a single reset event.
 /// </summary>
 public void AddRange(IEnumerable<T> items)
    {
  if (items == null) return;
 CheckReentrancy();
      bool any = false;
  foreach (var it in items)
       {
     Items.Add(it);
 any = true;
       }
       if (any)
  {
 OnCollectionChanged(new System.Collections.Specialized.NotifyCollectionChangedEventArgs(System.Collections.Specialized.NotifyCollectionChangedAction.Reset));
 }
   }

 /// <summary>
 /// Replaces all items in the collection and raises a single reset event.
 /// </summary>
 public void ReplaceAll(IEnumerable<T> items)
    {
  CheckReentrancy();
  Items.Clear();
  if (items != null)
  {
 foreach (var it in items) Items.Add(it);
  }
  OnCollectionChanged(new System.Collections.Specialized.NotifyCollectionChangedEventArgs(System.Collections.Specialized.NotifyCollectionChangedAction.Reset));
    }
    }
}
