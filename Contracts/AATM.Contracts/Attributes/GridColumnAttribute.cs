using System;

namespace AATM.Contracts.Attributes
{
    /// <summary>
    /// Defines a DataGridView column based on the DTO property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class GridColumnAttribute : Attribute
    {
        public string HeaderText { get; }
        public int Width { get; }
        public bool IsFillColumn { get; }

        public GridColumnAttribute(string headerText, int width = 100, bool isFillColumn = false)
        {
            HeaderText = headerText;
            Width = width;
            IsFillColumn = isFillColumn;
        }
    }
}