#if DEBUG
#define DESIGN_TIME_SAFE
#endif
using AATM.Contracts.Interfaces.Services;
using System;
using System.Windows.Forms;

namespace AATM.UI.Winforms.BaseControls
{
    // Design-time safe DTO implementing IEntityWithId
#if DESIGN_TIME_SAFE
    public abstract partial class StrictGridCrudForm : BaseGridCrudForm<DesignTimeDto>
#else
    public abstract class StrictGridCrudForm<T> : BaseGridCrudForm<T> where T : class, IEntityWithId
#endif
    {
        public StrictGridCrudForm()
        {
            InitializeComponent();
        }

#if DESIGN_TIME_SAFE
        protected StrictGridCrudForm(System.Func<ICrudService<DesignTimeDto>> factory) : base(factory) { }
        protected StrictGridCrudForm(ICrudService<DesignTimeDto> service) : base(service) { }
#else
        protected StrictGridCrudForm(System.Func<ICrudService<T>> factory) : base(factory) { }
        protected StrictGridCrudForm(ICrudService<T> service) : base(service) { }
#endif
        protected abstract override DataGridView Grid { get; }
    }

    public class DesignTimeDto : IEntityWithId
    {
        public int ID { get; set; }
        // Add other properties if needed for design-time visualization
    }
}