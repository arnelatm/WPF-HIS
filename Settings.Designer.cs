// Pseudocode:
// - Read raw value from _configuration by key
// - If null, return provided defaultValue
// - Determine target type T (handle Nullable<T> by extracting underlying type)
// - If string, return raw
// - If enum, parse ignoring case
// - Handle common primitives (Guid, TimeSpan, DateTime) with TryParse
// - Try TypeConverter from string
// - Fallback to Convert.ChangeType with InvariantCulture
// - On any failure, return defaultValue

public T GetValue<T>(string key, T defaultValue = default!)
{
    var raw = _configuration[key];
    if (raw is null) return defaultValue!;

    try
    {
        var t = typeof(T);
        var underlying = global::System.Nullable.GetUnderlyingType(t) ?? t;

        if (underlying == typeof(string))
            return (T)(object)raw;

        if (underlying.IsEnum)
            return (T)global::System.Enum.Parse(underlying, raw, ignoreCase: true);

        if (underlying == typeof(global::System.Guid) && global::System.Guid.TryParse(raw, out var g))
            return (T)(object)g;

        if (underlying == typeof(global::System.TimeSpan) && global::System.TimeSpan.TryParse(raw, out var ts))
            return (T)(object)ts;

        if (underlying == typeof(global::System.DateTime) &&
            global::System.DateTime.TryParse(raw, global::System.Globalization.CultureInfo.InvariantCulture,
                                             global::System.Globalization.DateTimeStyles.RoundtripKind, out var dt))
            return (T)(object)dt;

        var converter = global::System.ComponentModel.TypeDescriptor.GetConverter(underlying);
        if (converter is not null && converter.CanConvertFrom(typeof(string)))
        {
            var converted = converter.ConvertFromInvariantString(raw);
            return converted is null ? defaultValue! : (T)converted;
        }

        var convertedValue = global::System.Convert.ChangeType(raw, underlying, global::System.Globalization.CultureInfo.InvariantCulture);
        return (T)convertedValue;
    }
    catch
    {
        return defaultValue!;
    }
}