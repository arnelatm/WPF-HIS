using System;

namespace AATM.Contracts.Attributes
{
    /// <summary>
    /// Decorate DTO properties to drive automatic DataGridView column generation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class GridColumnAttribute : Attribute
    {
        public string Header { get; }
        public int Order { get; set; } = 0;
        public int Width { get; set; } = 100;
        public bool Fill { get; set; }
        public bool Hidden { get; set; }
        public bool ReadOnly { get; set; } = true;

        public GridColumnAttribute(string header)
        {
            Header = header;
        }
    }
}