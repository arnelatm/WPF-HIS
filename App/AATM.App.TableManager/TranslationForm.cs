using AATM.Business.Logic.Validators;
using AATM.Contracts.Dtos;
using AATM.Core.Localization;
using AATM.Modules.Localization;
using AATM.UI.Winforms.BaseControls;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AATM.App.TableManager
{
    public partial class TranslationForm : BaseGridCrudForm
    {
        // Removed local BindingSource (was shadowing the base class BindingSource and contributed to binding failure)

        public TranslationForm() : base(nameof(TranslationForm))
        {
            InitializeComponent();

            var localizationService = new LocalizationService("en-US", "TranslationForm");
            var languages = localizationService.GetWindowsAvailableLanguages()
                .Select(l => new LanguageItem { Name = l.display, Code = l.languageCode })
                .ToList();

            var comboBoxDataSources = new Dictionary<string, object>
            {
                { nameof(TranslationDto.LanguageCode), languages }
            };

            // Configure CRUD (this creates the internal BindingSource; we will re-bind ComboBox afterward)
            ForDto<TranslationDto>()
                .Service(() => new TranslationCrudService())
                .Validator(d => DtoValidator.Validate(d, TranslationDtoValidationRules.Rules))
                .ErrorDisplay(txtErrors)
                .AutoBind(true) // initial auto-bind (will be corrected for the ComboBox below)
                .Apply();

            // Re-run auto binding WITH our comboBoxDataSources so the ComboBox gets a DataSource.
            // This safely clears previous bindings on the controls it processes.
            AutoBindFormFields(typeof(TranslationDto), comboBoxDataSources);
        }

        protected override DataGridView Grid => _dataGridView;
    }

    public class LanguageItem
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}   