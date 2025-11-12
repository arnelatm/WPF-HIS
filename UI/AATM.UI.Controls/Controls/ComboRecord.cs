using System;
using System.Data;

namespace AATM.UI.Controls
{
    internal class ComboRecord
    {
        /// <summary>
        /// Gets or sets the raw underlying data object for this record.
        /// </summary>
        public object Raw { get; set; }
        /// <summary>
        /// Gets or sets the IdNo value for this record.
        /// </summary>
        public object IdNo { get; set; } = new object();
        /// <summary>
        /// Gets the uppercase version of the Code property for fast matching.
        /// </summary>
        public string CodeUpper { get; private set; } = string.Empty;
        /// <summary>
        /// Gets the uppercase version of the Name property for fast matching.
        /// </summary>
        public string NameUpper { get; private set; } = string.Empty;

        private string _code = string.Empty;
        private string _name = string.Empty;
        /// <summary>
        /// Gets or sets the Code value for this record.
        /// </summary>
        public string Code
        {
            get => _code;
            set
            {
                _code = value ?? string.Empty;
                CodeUpper = _code.ToUpperInvariant();
            }
        }
        /// <summary>
        /// Gets or sets the Name value for this record.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                _name = value ?? string.Empty;
                NameUpper = _name.ToUpperInvariant();
            }
        }
        /// <summary>
        /// Gets the display text for this record (Code - Name or Name).
        /// </summary>
        public string Display => string.IsNullOrEmpty(Code) ? Name : $"{Code} - {Name}";

        public bool Matches(string filter)
        {
            if (string.IsNullOrEmpty(filter)) return true;
            var f = filter.ToUpperInvariant();
            return CodeUpper.AsSpan().IndexOf(f.AsSpan()) >= 0 || NameUpper.AsSpan().IndexOf(f.AsSpan()) >= 0;
        }

        public override string ToString() => Display;

        public static ComboRecord FromUnknown(object obj)
        {
            if (obj == null) return null;
            if (obj is ComboRecord c) return c;

            if (obj is DataRowView drv)
            {
                return new ComboRecord
                {
                    Raw = obj,
                    IdNo = drv["IdNo"],
                    Code = drv["Code"]?.ToString() ?? "",
                    Name = drv["Name"]?.ToString() ?? ""
                };
            }
            if (obj is DataRow dr)
            {
                return new ComboRecord
                {
                    Raw = obj,
                    IdNo = dr["IdNo"],
                    Code = dr["Code"]?.ToString() ?? "",
                    Name = dr["Name"]?.ToString() ?? ""
                };
            }

            var map = ReflectionCache.Get(obj.GetType());
            if (map.IdNoProp != null || map.CodeProp != null || map.NameProp != null)
            {
                return new ComboRecord
                {
                    Raw = obj,
                    IdNo = map.IdNoProp?.GetValue(obj),
                    Code = map.CodeProp?.GetValue(obj)?.ToString() ?? "",
                    Name = map.NameProp?.GetValue(obj)?.ToString() ?? ""
                };
            }

            return new ComboRecord
            {
                Raw = obj,
                IdNo = obj,
                Code = "",
                Name = obj.ToString() ?? ""
            };
        }
    }
}
