using System;
using System.Collections.Generic;

namespace AATM.UI.Controls
{
    internal static class FilterEngine
    {
  internal readonly struct Result
   {
   public Result(int total, List<ComboRecord> page)
       {
     Total = total;
 Page = page;
 }
 /// <summary>
 /// Gets the total number of matches for the filter.
 /// </summary>
 public int Total { get; }
 /// <summary>
 /// Gets the page of filtered ComboRecord results.
 /// </summary>
 public List<ComboRecord> Page { get; }
        }

   public static Result FilterPage(List<ComboRecord> source, string filter, int skip, int take)
    {
        if (source == null || source.Count == 0)
      return new Result(0, new List<ComboRecord>());

        var fUpper = (filter ?? string.Empty).ToUpperInvariant();
  var f = fUpper.AsSpan();
   bool noFilter = f.Length == 0;

       int total = 0;
   var page = new List<ComboRecord>(Math.Max(0, take));

  for (int i = 0; i < source.Count; i++)
   {
 var rec = source[i];
      bool match = noFilter || rec.CodeUpper.AsSpan().IndexOf(f) >= 0 || rec.NameUpper.AsSpan().IndexOf(f) >= 0;
       if (!match) continue;

      if (total >= skip && page.Count < take)
 {
     page.Add(rec);
 }
 total++;
   }

       return new Result(total, page);
   }
    }
}
