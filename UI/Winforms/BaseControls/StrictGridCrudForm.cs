using AATM.Contracts.Interfaces.Services;
using System.Windows.Forms;

namespace AATM.UI.Winforms.BaseControls
{
    public abstract class StrictGridCrudForm<T> : BaseGridCrudForm<T> where T : class, IEntityWithId
    {
        protected StrictGridCrudForm() { }
        protected StrictGridCrudForm(System.Func<ICrudService<T>> factory) : base(factory) { }
        protected StrictGridCrudForm(ICrudService<T> service) : base(service) { }

        protected abstract override DataGridView Grid { get; }
        //protected abstract override void PopulateFormFieldsFromGrid(int rowIndex);
        //protected abstract override T BuildModelFromForm(T current);
        //protected abstract override int GetEntityId(T entity);
        //protected abstract override void ClearFormFieldsCore();
    }
}