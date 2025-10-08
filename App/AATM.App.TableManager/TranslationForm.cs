using AATM.Business.Logic.Validators;
using AATM.Contracts.Dtos;
using AATM.Modules.Localization;
using AATM.UI.Winforms.BaseControls;
using AATM.UI.Winforms.Localization;
using System.Collections.Generic;
using System.Windows.Forms;
using static AATM.UI.Winforms.Localization.LanguageUiHelper;

namespace AATM.App.TableManager
{
    public partial class TranslationForm : BaseGridCrudForm
    {
        private BindingSource bindingSource;

        public TranslationForm() : base(nameof(TranslationForm))
        {
            InitializeComponent();
                   
            // Fluent configuration (designer-safe: method-level generics only)
            ForDto<TranslationDto>()
                .Service(() => new TranslationCrudService())
                .Validator(d => DtoValidator.Validate(d, TranslationDtoValidationRules.Rules))
                .ErrorDisplay(txtErrors)      // assumes a TextBox or Label named txtErrors exists on the form
                .AutoBind(true)               // auto bind fields annotated with FieldControlAttribute
                .Apply();
        }

        // The grid used by BaseGridCrudForm (designer must define _dataGridView)
        protected override DataGridView Grid
        {
            get { return _dataGridView; }
        }

    }
}
