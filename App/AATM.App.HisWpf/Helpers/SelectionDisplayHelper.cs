using System.Collections;
using System.Collections.Concurrent;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;

namespace AATM.App.HisWpf.Helpers
{
    /// <summary>
    /// Helpers to get a human readable display value for a lookup item by id.
    /// - Prefer the generic overload with selectors for best performance & type-safety.
    /// - Backwards-compatible non-generic overload uses cached compiled accessors to avoid repeated reflection.
    /// </summary>
    public static class SelectionDisplayHelper
    {
        // Cache compiled accessors per item Type to avoid repeated reflection.
        private static readonly ConcurrentDictionary<Type, CachedAccessors> s_cache = new();

        /// <summary>
        /// Fast, strongly-typed lookup. Prefer this overload when you can provide typed selectors.
        /// </summary>
        public static string? GetDisplayTextById<T>(IEnumerable<T>? items, int id, Func<T, int>? idSelector = null, Func<T, string?>? displaySelector = null)
        {
            if (items == null) return null;

            // If callers supply selectors, use them (fast, no reflection).
            if (idSelector != null && displaySelector != null)
            {
                foreach (var item in items)
                {
                    try
                    {
                        if (idSelector(item) == id)
                        {
                            return displaySelector(item);
                        }
                    }
                    catch
                    {
                        // swallow per-item exceptions and continue to next
                    }
                }
                return null;
            }

            // Try best-effort: if T is object / unknown, fall back to the non-generic cached reflection path.
            var en = items as IEnumerable;
            if (en == null) return null;

            return GetDisplayTextById(en, id);
        }

        /// <summary>
        /// Backwards-compatible API used by existing callers.
        /// Uses cached, compiled delegates for IdNo and DisplayText access to reduce reflection cost.
        /// </summary>
        public static string? GetDisplayTextById(IEnumerable? items, int id)
        {
            if (items == null) return null;

            foreach (var item in items)
            {
                if (item == null) continue;

                var t = item.GetType();
                var acc = s_cache.GetOrAdd(t, BuildAccessors);

                try
                {
                    var idValue = acc.IdAccessor(item);
                    if (idValue == null) continue;

                    // normalize to int for comparison
                    int candidate;
                    try
                    {
                        candidate = Convert.ToInt32(idValue, CultureInfo.InvariantCulture);
                    }
                    catch
                    {
                        // unable to convert id value to int
                        continue;
                    }

                    if (candidate != id) continue;

                    var dispValue = acc.DisplayAccessor(item);
                    if (dispValue != null) return dispValue.ToString();

                    // fallback to ToString()
                    return item.ToString();
                }
                catch
                {
                    // ignore item-level exceptions and continue
                }
            }

            return null;
        }

        // New convenience overloads: try multiple sources in order and return first non-empty display text.
        /// <summary>
        /// Try typed sources in order. Prefer this when you have strongly-typed collections.
        /// Usage: GetDisplayTextById&lt;T&gt;(id, primaryView, availableList)
        /// </summary>
        public static string? GetDisplayTextById<T>(int id, params IEnumerable<T>?[] sources)
        {
            if (sources == null) return null;
            foreach (var src in sources)
            {
                if (src == null) continue;
                var disp = GetDisplayTextById<T>(src, id);
                if (!string.IsNullOrEmpty(disp)) return disp;
            }
            return null;
        }

        /// <summary>
        /// Try typed sources in order using explicit selectors if provided.
        /// Usage: GetDisplayTextById&lt;T&gt;(id, idSelector, displaySelector, primaryView, availableList)
        /// </summary>
        public static string? GetDisplayTextById<T>(int id, Func<T, int>? idSelector, Func<T, string?>? displaySelector, params IEnumerable<T>?[] sources)
        {
            if (sources == null) return null;
            foreach (var src in sources)
            {
                if (src == null) continue;
                var disp = GetDisplayTextById<T>(src, id, idSelector, displaySelector);
                if (!string.IsNullOrEmpty(disp)) return disp;
            }
            return null;
        }

        /// <summary>
        /// Try untyped sources in order. Useful when some sources are non-generic (ICollectionView, IEnumerable).
        /// Usage: GetDisplayTextById(id, viewAsEnumerable, availableList)
        /// </summary>
        public static string? GetDisplayTextById(int id, params IEnumerable?[] sources)
        {
            if (sources == null) return null;
            foreach (var src in sources)
            {
                if (src == null) continue;
                var disp = GetDisplayTextById(src, id);
                if (!string.IsNullOrEmpty(disp)) return disp;
            }
            return null;
        }

        // Cache container for compiled accessors
        private sealed class CachedAccessors
        {
            public CachedAccessors(Func<object, object?> idAccessor, Func<object, object?> displayAccessor)
            {
                IdAccessor = idAccessor;
                DisplayAccessor = displayAccessor;
            }

            public Func<object, object?> IdAccessor { get; }
            public Func<object, object?> DisplayAccessor { get; }
        }

        // Build compiled accessors for the given Type.
        // Looks for 'IdNo' (property/field) and 'DisplayText' (property/field).
        private static CachedAccessors BuildAccessors(Type itemType)
        {
            var idAccessor = BuildAccessor(itemType, "IdNo");
            var displayAccessor = BuildAccessor(itemType, "DisplayText");

            // If display accessor is not found, create a fallback that calls ToString()
            if (displayAccessor == null)
            {
                displayAccessor = CreateToStringAccessor(itemType);
            }

            // If id accessor is not found, create an accessor that returns null for id
            if (idAccessor == null)
            {
                idAccessor = _ => null;
            }

            return new CachedAccessors(idAccessor, displayAccessor);
        }

        // Create a Func<object, object?> accessor for a property or field name. Returns null if not found.
        private static Func<object, object?>? BuildAccessor(Type itemType, string memberName)
        {
            // Try property
            var prop = itemType.GetProperty(memberName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (prop != null && prop.GetMethod != null)
            {
                return CreatePropertyAccessor(itemType, prop);
            }

            // Try field
            var field = itemType.GetField(memberName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (field != null)
            {
                return CreateFieldAccessor(itemType, field);
            }

            return null;
        }

        private static Func<object, object?> CreatePropertyAccessor(Type itemType, PropertyInfo prop)
        {
            var objParam = Expression.Parameter(typeof(object), "o");
            var cast = Expression.Convert(objParam, itemType);
            var access = Expression.Property(cast, prop);
            var convert = Expression.Convert(access, typeof(object));
            var lambda = Expression.Lambda<Func<object, object?>>(convert, objParam);
            return lambda.Compile();
        }

        private static Func<object, object?> CreateFieldAccessor(Type itemType, FieldInfo field)
        {
            var objParam = Expression.Parameter(typeof(object), "o");
            var cast = Expression.Convert(objParam, itemType);
            var access = Expression.Field(cast, field);
            var convert = Expression.Convert(access, typeof(object));
            var lambda = Expression.Lambda<Func<object, object?>>(convert, objParam);
            return lambda.Compile();
        }

        private static Func<object, object?> CreateToStringAccessor(Type itemType)
        {
            var objParam = Expression.Parameter(typeof(object), "o");
            var cast = Expression.Convert(objParam, itemType);
            var toStringCall = Expression.Call(cast, itemType.GetMethod("ToString", Type.EmptyTypes)!);
            var convert = Expression.Convert(toStringCall, typeof(object));
            var lambda = Expression.Lambda<Func<object, object?>>(convert, objParam);
            return lambda.Compile();
        }
    }
}