using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;

namespace AATM.UI.Controls
{
    internal static class ReflectionCache
    {
    internal sealed class CachedMap
    {
  public CachedMap(Type t)
   {
 var props = t.GetProperties(BindingFlags.Instance | BindingFlags.Public);
     var dict = new Dictionary<string, PropertyInfo>(StringComparer.OrdinalIgnoreCase);
       foreach (var p in props)
 {
     dict[p.Name] = p;
     if (string.Equals(p.Name, "IdNo", StringComparison.OrdinalIgnoreCase)) IdNoProp = p;
     else if (string.Equals(p.Name, "Code", StringComparison.OrdinalIgnoreCase)) CodeProp = p;
     else if (string.Equals(p.Name, "Name", StringComparison.OrdinalIgnoreCase)) NameProp = p;
       }
 AllProps = dict;
 }
 /// <summary>
 /// Gets the property info for IdNo, Code, and Name for a given type.
 /// </summary>
 public PropertyInfo IdNoProp { get; }
 /// <summary>
 /// Gets the property info for Code for a given type.
 /// </summary>
 public PropertyInfo CodeProp { get; }
 /// <summary>
 /// Gets the property info for Name for a given type.
 /// </summary>
 public PropertyInfo NameProp { get; }
 /// <summary>
 /// Gets all public property infos for a given type.
 /// </summary>
 public Dictionary<string, PropertyInfo> AllProps { get; }
   }

    private static readonly ConcurrentDictionary<Type, CachedMap> _maps = new();
 /// <summary>
 /// Gets a cached map of property infos for the given type.
 /// </summary>
 public static CachedMap Get(Type t) => _maps.GetOrAdd(t, static tt => new CachedMap(tt));

 /// <summary>
 /// Tries to get the value of a property by name from an object.
 /// </summary>
 public static bool TryGetPropValue(object obj, string propName, out object value)
  {
 value = null;
       if (obj == null || string.IsNullOrWhiteSpace(propName)) return false;
  var map = Get(obj.GetType());
  if (map.AllProps.TryGetValue(propName, out var pi))
   {
       value = pi.GetValue(obj);
       return true;
        }
        return false;
  }
    }
}
