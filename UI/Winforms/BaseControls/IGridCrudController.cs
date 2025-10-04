using System;
using System.Collections;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AATM.UI.Winforms.BaseControls
{
    // Updated: added access to the live typed list + metadata for auto column generation.
    internal interface IGridCrudController
    {
        Type DtoType { get; }

        // Live strongly typed list exposed as non-generic for BindingSource.
        BindingList<object> LiveUntypedItems { get; }

        // Load from service
        Task LoadAsync(CancellationToken ct);

        // Create a fresh DTO instance
        object CreateNew();

        // Persist (insert/update)
        Task<object> SaveAsync(object model, CancellationToken ct);

        // Delete by id
        Task<bool> DeleteAsync(int id, CancellationToken ct);

        // Filtering (non‑mutating)
        IEnumerable<object> Filter(string query);

        // Sorting (non‑mutating)
        IEnumerable<object> Sort(string propertyName, bool ascending);

        // Get primary key
        int GetId(object entity);

        // Expose property descriptors for optional auto-column generation
        IReadOnlyList<GridPropertyDescriptor> GridProperties { get; }
    }

    internal sealed class GridPropertyDescriptor
    {
        public string Name { get; }
        public Type PropertyType { get; }
        public GridPropertyDescriptor(string name, Type type)
        {
            Name = name;
            PropertyType = type;
        }
    }
}