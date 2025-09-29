using AATM.Contracts.Interfaces.Services;
using System.Windows.Forms;

namespace AATM.UI.Winforms.BaseControls
{
    //public abstract class StrictGridCrudForm<T> : BaseGridCrudForm<T> where T : class, IEntityWithId
#if DESIGN_TIME_SAFE
    public abstract class StrictGridCrudForm<T> : BaseGridCrudForm<T> where T : class
#else
    public abstract class StrictGridCrudForm<T> : BaseGridCrudForm<T> where T : class, IEntityWithId
#endif
    {
        protected StrictGridCrudForm() { }
        protected StrictGridCrudForm(System.Func<ICrudService<T>> factory) : base(factory) { }
        protected StrictGridCrudForm(ICrudService<T> service) : base(service) { }

        protected abstract override DataGridView Grid { get; }
        //protected abstract override void PopulateFormFieldsFromGrid(int rowIndex);
        //protected abstract override T BuildModelFromForm(T current);
        //protected abstract override int GetEntityId(T entity);
        //protected abstract override void ClearFormFieldsCore();


        protected override void OnCreateAdditionalNavigatorItems(BindingNavigator navigator)
        {
            //base.OnCreateAdditionalNavigatorItems(navigator);

            //navigator.Items.Add(new ToolStripSeparator());

            //_languageCombo = new ToolStripComboBox
            //{
            //    Name = "tscLanguage",
            //    DropDownStyle = ComboBoxStyle.DropDownList,
            //    ToolTipText = "Select UI language"
            //};
            //_languageCombo.SelectedIndexChanged += (s, e) => ApplySelectedLanguage();

            //_applyLangButton = new ToolStripButton("Apply")
            //{
            //    ToolTipText = "Apply selected language to this form"
            //};
            //_applyLangButton.Click += (s, e) => ApplySelectedLanguage();

            //navigator.Items.Add(new ToolStripLabel("Lang:"));
            //navigator.Items.Add(_languageCombo);
            //navigator.Items.Add(_applyLangButton);
        }
    }
}