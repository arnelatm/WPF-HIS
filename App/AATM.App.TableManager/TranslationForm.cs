using AATM.Business.Logic.Validators;
using AATM.Contracts.Dtos;
using AATM.Modules.Localization;
using AATM.UI.Winforms.BaseControls;
using System.Windows.Forms;

namespace AATM.App.TableManager
{
    public partial class TranslationForm : BaseGridCrudForm
    {
        public TranslationForm() : base(nameof(TranslationForm))
        {
            InitializeComponent();

            InitializeErrorHandling(txtErrors); 

            InitializeTypedController<TranslationDto>(() => new TranslationCrudService());

            AutoBindFormFields(typeof(TranslationDto));

            StructuredValidator = e => DtoValidator.Validate((TranslationDto)e, TranslationDtoValidationRules.Rules);
        }

        protected override DataGridView Grid => _dataGridView;

    }
}
