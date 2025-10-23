using System;
using System.Collections;
using System.Globalization;

namespace AATM.App.HisWpf.Helpers
{
    // Helper to locate an item's display text by id using reflection
    // Keeps selection-to-display synchronization logic in one place.
    public static class SelectionDisplayHelper
    {
        public static string? GetDisplayTextById(IEnumerable? items, int id)
        {
            if (items == null) return null;

            foreach (var item in items)
            {
                if (item == null) continue;
                try
                {
                    var t = item.GetType();
                    var idProp = t.GetProperty("IdNo");
                    if (idProp == null) continue;

                    var val = idProp.GetValue(item);
                    if (val == null) continue;

                    // Convert to int for comparison
                    if (Convert.ToInt32(val, CultureInfo.InvariantCulture) != id) continue;

                    var dispProp = t.GetProperty("DisplayText");
                    if (dispProp != null)
                    {
                        var d = dispProp.GetValue(item);
                        return d?.ToString();
                    }

                    // Fallback to ToString()
                    return item.ToString();
                }
                catch
                {
                    // ignore reflection issues
                }
            }

            return null;
        }
    }
}
