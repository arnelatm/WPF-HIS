using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace AATM.UI.Winforms.BaseControls
{
    // Internal: isolates typed logic from designable base Form.
    internal interface IGridCrudController
    {
        Type DtoType { get; }

        // Underlying strongly typed list, but exposed as object list for reuse by BindingSource.
        BindingList<object> UntypedItems { get; }

        // Load from service
        Task LoadAsync(CancellationToken ct);

        // Create a fresh DTO instance
        object CreateNew();

        // Persist (insert/update)
        Task<object> SaveAsync(object model, CancellationToken ct);

        // Delete by id
        Task<bool> DeleteAsync(int id, CancellationToken ct);

        // Return filtered enumerable (NOT mutating internal list – caller repopulates binding list)
        IEnumerable<object> Filter(string query);

        // Sort by property
        IEnumerable<object> Sort(string propertyName, bool ascending);

        // Get ID (for IEntityWithId abstraction)
        int GetId(object entity);   
    }
}